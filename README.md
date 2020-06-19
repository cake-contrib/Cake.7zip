# Cake.7zip

[![standard-readme compliant][]][standard-readme]
[![All Contributors](https://img.shields.io/badge/all_contributors-0-orange.svg?style=flat-square)](#contributors)
[![Appveyor build][appveyorimage]][appveyor]
[![Codecov Report][codecovimage]][codecov]
[![NuGet package][nugetimage]][nuget]

> makes [7zip](https://7-zip.org/) available as a tool in [cake](https://cakebuild.net/)

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
  - [Contributors](#contributors)
- [License](#license)

## Install

```cs
#tool nuget:?package=7-Zip.CommandLine
#addin nuget:?package=Cake.7zip
```

## Usage

### Adding files

```cs
#tool nuget:?package=7-Zip.CommandLine
#addin nuget:?package=Cake.7zip

SevenZip(s => s
  .InAddMode()
  .WithArchive(File("fluent.zip"))
  .WithArchiveType(SwitchArchiveType.Zip)
  .WithFiles(File("a.txt"), File("b.txt"))
  .WithVolume(700, VolumeUnit.Megabytes)
  .WithCompressionMethodLevel(9));
```

### Extracting files

```cs
#tool nuget:?package=7-Zip.CommandLine
#addin nuget:?package=Cake.7zip

SevenZip(s => s
  .InExtractMode()
  .WithArchive(File("path/to/file.zip"))
  .WithArchiveType(SwitchArchiveType.Zip)
  .WithOutputDirectory("some/other/directory"));
```

## Maintainer

[Nils Andresen @nils-a][maintainer]

## Contributing

Cake.7zip follows the [Contributor Covenant][contrib-covenant] Code of Conduct.

We accept Pull Requests.

Small note: If editing the Readme, please conform to the [standard-readme][] specification.

This project follows the [all-contributors][] specification. Contributions of any kind welcome!

### Contributors

Thanks goes to these wonderful people ([emoji key][emoji-key]):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- prettier-ignore -->
<!-- ALL-CONTRIBUTORS-LIST:END -->

## License

[MIT License © Nils Andresen][license]

[all-contributors]: https://github.com/all-contributors/all-contributors
[appveyor]: https://ci.appveyor.com/project/cakecontrib/cake-7zip
[appveyorimage]: https://img.shields.io/appveyor/ci/cakecontrib/cake-7zip.svg?logo=appveyor&style=flat-square
[codecov]: https://codecov.io/gh/cake-contrib/Cake.7zip
[codecovimage]: https://img.shields.io/codecov/c/github/cake-contrib/Cake.7zip.svg?logo=codecov&style=flat-square
[contrib-covenant]: https://www.contributor-covenant.org/version/1/4/code-of-conduct
[emoji-key]: https://allcontributors.org/docs/en/emoji-key
[maintainer]: https://github.com/nils-a
[nuget]: https://nuget.org/packages/Cake.7zip
[nugetimage]: https://img.shields.io/nuget/v/Cake.7zip.svg?logo=nuget&style=flat-square
[license]: LICENSE.txt
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
