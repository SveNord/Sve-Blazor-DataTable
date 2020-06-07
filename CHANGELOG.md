# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

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
