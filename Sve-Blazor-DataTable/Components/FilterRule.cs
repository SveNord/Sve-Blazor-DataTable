using Sve.Blazor.Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sve.Blazor.DataTable.Components
{
    public class FilterRule<TModel>
    {
        public Guid Guid { get; private set; }

        public DataTableColumn<TModel> Column { get; private set; }

        public string PropertyName { get; private set; }

        public ObjectFilter FilterType { get; set; }

        public Type ExpectedValueType { get; private set; }

        public dynamic? FilterValue { get; private set; } = null;

        public bool IsApplied { get; set; } = false;

        public bool IsNullable { get; private set; } = false;

        public FilterRule(DataTableColumn<TModel> column, Type propertyType, string propertyName, ObjectFilter objectFilter)
        {
            Guid = Guid.NewGuid();
            Column = column;
            FilterType = objectFilter;
            PropertyName = propertyName;
            
            UpdatePropertyType(propertyType);
        }

        public void UpdateFilterProperty(DataTableColumn<TModel> column, Type propertyType, string propertyName)
        {
            Column = column;
            PropertyName = propertyName;
            UpdatePropertyType(propertyType);
        }

        public void UpdateFilterValue(ValueChangedEventArgs valueChangedEventArgs)
        {
            FilterValue = valueChangedEventArgs.Value;
        }

        public Expression<Func<TModel, bool>> GenerateExpression() => FilterType.GenerateExpression<TModel>(Column.GetColumnVisualPropertyName(), FilterValue);

        private void UpdatePropertyType(Type propertyType)
        {
            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                propertyType = Nullable.GetUnderlyingType(propertyType);
                IsNullable = true;
            }

            ExpectedValueType = propertyType;

            if (propertyType.IsEnum) FilterValue = Enum.GetNames(propertyType)[0];
            else
            {
                switch (Type.GetTypeCode(propertyType))
                {
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    case TypeCode.Double:
                    case TypeCode.Decimal:
                        FilterValue = 0;
                        break;
                    case TypeCode.Boolean:
                        FilterValue = false;
                        break;
                    case TypeCode.String:
                        FilterValue = "";
                        break;
                    case TypeCode.DateTime:
                        FilterValue = DateTime.UtcNow;
                        break;

                    // TODO: Some types might be possible
                    case TypeCode.Object:
                    case TypeCode.Char:
                    case TypeCode.Byte:
                    case TypeCode.SByte:
                    case TypeCode.Single:
                        throw new Exception("Unsupported property type for filtering");
                }
            }
        }

        public string GetAppliedFilterRuleText()
        {
            if (FilterType.ValueRequired) return $"{PropertyName}\t{FilterType.ToString()}\t{FilterValue}";
            else return $"{PropertyName}\t{FilterType.ToString()}";
        }
    }
}
