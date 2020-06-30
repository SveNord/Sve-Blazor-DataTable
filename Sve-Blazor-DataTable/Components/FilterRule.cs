using Sve.Blazor.Core.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Sve.Blazor.DataTable.Components
{
    public class
        FilterRule<TModel>
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

        public Expression<Func<TModel, bool>> GenerateExpression()
        {
            if (Type.GetTypeCode(ExpectedValueType) == TypeCode.DateTime)
            {
                if (Column.DateTimeFormat == DateTimeFormat.Date) return FilterType.GenerateExpression<TModel>($"{Column.GetColumnPropertyName()}.Date", FilterValue.Date);
                else if (Column.DateTimeFormat == DateTimeFormat.DateHourMinute)
                {
                    var dateExpression = FilterType.GenerateExpression<TModel>($"{Column.GetColumnPropertyName()}.Date", FilterValue.Date);
                    var hourExpression = FilterType.GenerateExpression<TModel>($"{Column.GetColumnPropertyName()}.Hour", FilterValue.Hour);
                    var minuteExpression = FilterType.GenerateExpression<TModel>($"{Column.GetColumnPropertyName()}.Minute", FilterValue.Minute);
                    var p1 = PredicateBuilder.And(dateExpression, hourExpression);
                    return PredicateBuilder.And(p1, minuteExpression);
                }
                else if (Column.DateTimeFormat == DateTimeFormat.DateHourMinuteSecond)
                {
                    return FilterType.GenerateExpression<TModel>(Column.GetColumnPropertyName(), FilterValue);
                }
            }

            return FilterType.GenerateExpression<TModel>(Column.GetColumnPropertyName(), FilterValue);
        }

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
                        FilterValue = default(System.Int16);
                        break;
                    case TypeCode.Int32:
                        FilterValue = default(System.Int32);
                        break;
                    case TypeCode.Int64:
                        FilterValue = default(System.Int64);
                        break;
                    case TypeCode.UInt16:
                        FilterValue = default(System.UInt16);
                        break;
                    case TypeCode.UInt32:
                        FilterValue = default(System.UInt32);
                        break;
                    case TypeCode.UInt64:
                        FilterValue = default(System.UInt64);
                        break;
                    case TypeCode.Double:
                        FilterValue = default(System.Double);
                        break;
                    case TypeCode.Decimal:
                        FilterValue = default(System.Decimal);
                        break;
                    case TypeCode.Byte:
                        FilterValue = default(System.Byte);
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
                    case TypeCode.SByte:
                    case TypeCode.Single:
                        throw new Exception("Unsupported property type for filtering");
                }
            }
        }

        public string GetAppliedFilterRuleText()
        {
            if (FilterType.ValueRequired)
            {
                if (Type.GetTypeCode(ExpectedValueType) == TypeCode.DateTime) return $"{Column.GetColumnVisualPropertyName()}\t{FilterType.ToString()}\t{FilterValue!.ToString(Column.DateTimeFormat.Format)}";
                else return $"{Column.GetColumnVisualPropertyName()}\t{FilterType.ToString()}\t{FilterValue}";
            }
            else return $"{Column.GetColumnVisualPropertyName()}\t{FilterType.ToString()}";
        }
    }
}
