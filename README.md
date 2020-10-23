# TrueLayer Take Home Challenge

## Instructions

You can launch the programs in two ways:

1. [Docker](#Docker) (recommended)
2. [Installing .NET Core SDK](#Installing-.NET-Core-SDK)

### Docker

#### **Prerequisites**

You only need Docker, please refer to the official [Docker documentation](https://www.docker.com/get-started), depending on your platform.

> **Note**: if you are using Windows, you must select Linux Containers.
>
> To run Linux Container under Windows, you need to [enable Hyper-V](https://docs.microsoft.com/en-us/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v).

#### **Instructions**

1. Open the Terminal
2. Go to the root folder of this repository
3. Run the command `docker build . -t truelayer`
	- `truelayer` will be the name of the Docker image, you can change it as you wish
4. Run the command `docker run --rm --name truelayer-container -p 5000:80 truelayer`
	- The `--rm` flag will destroy the container when you stop it; if you want to keep it, remove this flag
	- The `-p 5000:80` flag and argument will map port `5000` of your machine to port `80` of the container, you can change `5000` with any other port

> **Note**: To stop the program run: `docker stop truelayer-container`.

### Installing .NET Core SDK

#### **Prerequisites**

You need to download and install .NET Core 3.1 SDK, please refer to the [instruction on Microsoft's website](https://dotnet.microsoft.com/download/dotnet-core/3.1) depending on your platform.
You can check the installed version with `dotnet --version`, it should be `3.1.xyz`.

#### **Instructions**

1. Open the Terminal
2. Go to the root folder of this repository
3. Move to `src/TrueLayer.WebApi` folder
4. Run with `dotnet run -c Release`

> **Note**: To stop the program hit `CTRL` + `C` on the Terminal window.

## Usage

Using your favorite tool (e.g. `curl`, `httpie` or just your browser) navigate to

`GET http://localhost:5000/pokemon/name`

Where `name` is the name of the Pokémon you want to read the Shakespearean Pokédex Description.

> **Note**: For a limitation by the translation API, only 5 call / hour can be made.
>
> Any additional request will return an `HTTP 429 Too Many Requests`.

## Testing

The project comes with three simple tests. You can run them only by [installing .NET Core SDK](#Installing-.NET-Core-SDK).

#### **Prerequisites**

Please have a look at the [installing .NET Core SDK](#Installing-.NET-Core-SDK) prerequisites section.

#### **Instructions**

1. Open the Terminal
2. Go to the root folder of this repository
3. Move to `test/TrueLayer.Tests` folder
4. Run `dotnet test`