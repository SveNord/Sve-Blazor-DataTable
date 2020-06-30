# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [1.0.10-alpha] - 2020-06-30
### Added
- Item height property

## [1.0.9-alpha] - 2020-06-11
### Fixed
- Fixed Date filters issues
- Fixed issue with filterable and non filterable columns in combination with grid filters 

## [1.0.8-alpha] - 2020-06-10
### Fixed
- Fixed duplicatation issue

## [1.0.7-alpha] - 2020-06-10
### Fixed
- Fixed more consistency issues

## [1.0.6-alpha] - 2020-06-10
### Fixed
- Fixed consistency issue

## [1.0.5-alpha] - 2020-06-09
### Added
- IsHeaderVisible property to control header visibility
- HeaderTemplate
- IncludeAdvancedFilters property
- DataTableColumn accepts attributes
- ApplyButtonCssClass to add classes to apply buttons in  header/grid filters
- InputCssClass to add classes to inputs in header/grid filters
- EmptyGridText property to show empty text when there are no items
- IsLoading property
- Cursor pointer on selectable tables
- Guid for modals
- Added HeaderFilterAttributes property
- Added DateTimeFormat property for date header/grid filters
- Added DateInput
- Added RowAttributes property
- Added overflow styles on rows

### Changed
- Moved IncludeHeaderFilters from DataTableColumn to DataTable
to increase consistency in the UI when this is used
- Renamed 'Template' in DataTableColumn to 'RowTemplate'

### Fixed
- Fixed default values for 'primitive' types
- A lot of smaller issues

## [1.0.4-alpha] - 2020-06-07
### Added
- A callback for when a row is clicked
- Selectable rows

## [1.0.3-alpha] - 2020-06-07
### Fixed
- Fixed an issue where FetchData was called before the Columns were initialized

## [1.0.2-alpha] - 2020-06-07
### Fixed
- Nested properties in TableColumn 
- Better expression generation for Contains, NotContains, StartsWith and EndsWith to avoid client eval when using EF-Core
- Unapplying a header/grid filter now behaves the same way as applying one (SearchOnApplyHeaderFilter)
- The property selector in the filter rule modal now shows the CustomTitle property of the column if it has one

## [1.0.1-alpha] - 2020-06-06
### Added
- Header/Grid filters

### Fixed
- Issue with expression generation for enums

## [1.0.0-alpha] - 2020-06-05
### Added
- Initial major alpha release
