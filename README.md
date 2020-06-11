# Cake.7zip

[![standard-readme compliant][]][standard-readme]
[![All Contributors](https://img.shields.io/badge/all_contributors-0-orange.svg?style=flat-square)](#contributors)
[![Appveyor build][appveyorimage]][appveyor]
[![Codecov Report][codecovimage]][codecov]
[![NuGet package][nugetimage]][nuget]

> makes 7zip available as a tool in cake

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
  - [Contributors](#contributors)
- [License](#license)

## Install

```cs
#addin nuget:?package=Cake.7zip
```

## Usage

```cs
#addin nuget:?package=Cake.7zip

Task("MyTask").Does(() => {
  7zip();
});
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
[appveyor]: https://ci.appveyor.com/project/nilsa/cake-7zip
[appveyorimage]: https://img.shields.io/appveyor/ci/nilsa/cake-7zip.svg?logo=appveyor&style=flat-square
[codecov]: https://codecov.io/gh/nils-a/Cake.7zip
[codecovimage]: https://img.shields.io/codecov/c/github/nils-a/Cake.7zip.svg?logo=codecov&style=flat-square
[contrib-covenant]: https://www.contributor-covenant.org/version/1/4/code-of-conduct
[emoji-key]: https://allcontributors.org/docs/en/emoji-key
[maintainer]: https://github.com/nils-a
[nuget]: https://nuget.org/packages/Cake.7zip
[nugetimage]: https://img.shields.io/nuget/v/Cake.7zip.svg?logo=nuget&style=flat-square
[license]: LICENSE.txt
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
