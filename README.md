<!-- PROJECT LOGO -->
<br />
<p align="center">
  <h3 align="center">WAccount</h3>

  <p align="center">
    A project build with .NET Core and Angular, with MySQL as database
    <br />
    <a href="https://github.com/guilhermeschreiber/waccount"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/guilhermeschreiber/waccount">View Demo</a>
    ·
    <a href="https://github.com/guilhermeschreiber/waccount/issues">Report Bug</a>
    ·
    <a href="https://github.com/guilhermeschreiber/repo/issues">Request Feature</a>
  </p>
</p>

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
  * [Architecture](#architecture)
  * [Tests](#tests)
  * [API](#architecture)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
  * [Screenshots](#screenshots)
* [Roadmap](#roadmap)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)
* [Acknowledgements](#acknowledgements)



<!-- ABOUT THE PROJECT -->
## About The Project

The purpose of the application is to manage transactions and user income. Financial income is updated daily. To perform transactions, the user must be logged in

### Architecture
Based on Domain Driven Design (DDD)

![](https://raw.githubusercontent.com/guilhermeschreiber/WAccount/master/images/solution.png)

### Tests

![](https://raw.githubusercontent.com/guilhermeschreiber/WAccount/master/images/tests.png)

### API


Except for the login API, authentication is required to use the API.

To authenticate, use the login API and obtain the bearer token at x-access-token header.

![](https://raw.githubusercontent.com/guilhermeschreiber/WAccount/master/images/api.png)

### Built With

* ASP .NET 3.1
* Angular 6
* Node 10
* MySQL with Entity Framework


<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

To build and run this application, must be installed on the computer:
* npm
```sh
npm install npm@latest -g
```
* Visual Studio 2019
* MySQL Database

### Installation
 
1. Clone the repo
```sh
git clone https://github.com/guilhermeschreiber/waccount.git
```
2. Install NPM packages and build angular
```sh
cd front
npm install
ng build
```
3. Configure the appsettings.json with your connection string
4. Build with Visual Studio
5. Run with iSS express embedded in Visual Studio


<!-- USAGE EXAMPLES -->
## Usage

By default, the only user registered to use the system is:
```sh
email: admin@admin.com
password: 123
```
To add new users, you must at least be authenticated with the standard user. Or, if you choose to change the database, be sure to use the MD5 encrypted password

### Screenshots

![](https://raw.githubusercontent.com/guilhermeschreiber/WAccount/master/images/transactions.png)
![](https://raw.githubusercontent.com/guilhermeschreiber/WAccount/master/images/add.png)
![](https://raw.githubusercontent.com/guilhermeschreiber/WAccount/master/images/login.png)


<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/guilhermeschreiber/waccount/issues) for a list of proposed features (and known issues).


<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.


<!-- CONTACT -->
## Contact

Guilherme Schreiber - guilhermeschreiber@gmail.com
[![LinkedIn][linkedin-shield]][linkedin-url]

Project Link: [https://github.com/guilhermeschreiber/waccount](https://github.com/guilhermeschreiber/waccount)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* https://www.devmedia.com.br/introducao-ao-ddd-em-net/32724
* https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-3.0
* https://www.blbbrasil.com.br/blog/matematica-financeira-contabilidade/
* https://medium.com/@alexalvess/criando-uma-api-em-net-core-baseado-na-arquitetura-ddd-2c6a409c686
* https://medium.com/@renato.groffe/asp-net-core-2-0-autentica%C3%A7%C3%A3o-em-apis-utilizando-jwt-json-web-tokens-4b1871efd





<!-- MARKDOWN LINKS -->
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/guilherme-schreiber-41020b102/
