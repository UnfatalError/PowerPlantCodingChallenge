# How to launch
## Visual Studio
**Requirements:**: .NET 7 SDK, Visual Studio 2022
1. Open Visual Studio.
2. Choose the "ProductionPlan" profile from the available profiles.
3. Click the "Run" button to start the API.
## .NET CLI
**Requirements:**: .NET 7 SDK
Navigate to the "PowerPlantCodingChallenge\PowerPlantProduction.Api" directory and use the following command to run the API in the "Production" environment:
	dotnet run [--environment Production]
## Docker
**Requirements:**: .NET 7 SDK, Docker
Build a Docker image and run it as a container:
1. Open a command prompt.
2. Navigate to the "PowerPlantCodingChallenge" directory.
3. Build an image with the following command, specifying your image name (e.g., "your_image_name"):
	docker build -f PowerPlantProduction.Api/Dockerfile -t your_image_name .
4. Start a container using the following command and specifying your container name (e.g., "your_container_name"):
	docker run -d -p 8888:80 --name your_container_name your_image_name
## Accessing the API
You can access the API by sending a POST request to the following URL: http://localhost:8888/api/productionplan
To send data to the API, you should provide the payload in JSON format, which should be included in the request body.