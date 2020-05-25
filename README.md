# Sve-Blazor-DataTable

Blazor DataTable component with support for client/server side paging, filtering and sorting, build on top of bootstrap 4.

<img src="https://static.pcactive.nl/images/PCA/PCA_309/giphy.gif" />
 
## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

What things you need to install the software and how to install them

```
Give examples
```

### Installation
1. Install the [NuGet](https://www.nuget.org/packages/Sve.Blazor.DataTable/) package:

   .NET CLI:
   ```
   dotnet add package Sve.Blazor.DataTable
   ```

   Package Manager:
   ```
   Install-Package Sve.Blazor.DataTable
   ```

   Use the `--version` option to specify a specific version to install.

   Or use the build in NuGet package manager of your favorite IDEA. Simply search for `Sve.Blazor.DataTable`, select a version and hit install.

2. Import the components:

   Add the following using statement `@using Sve.Blazor.DataTable` to one of the following: 
   - For global import add it to your  `_Imports.razor` file
   - For a scoped import add  it to your desired Blazor component

## Usage

### Basic table

```cs
<DataTable >
```


## Built With

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - The web framework used
* [Maven](https://maven.apache.org/) - Dependency Management
* [ROME](https://rometools.github.io/rome/) - Used to generate RSS Feeds

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags). 

## Authors

* **Billie Thompson** - *Initial work* - [PurpleBooth](https://github.com/PurpleBooth)

See also the list of [contributors](https://github.com/your/project/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
