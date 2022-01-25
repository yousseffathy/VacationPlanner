# VacationPlanner
This website is a vacation planner that allows you to search for cities according to their average temperature during the month of your planned vacation. You can plan, save, edit, and delete your plans from your calendar. This website was my learning tool on how to create a Rest API using .NET Core connected to a MongoDB with a js framework as the front end.

## Description
The website is built using a [dataset](https://www.kaggle.com/swapnilbhange/average-temperature-of-cities) collected from Kaggle. The dataset contains the average temperature of 446 cities all over the world. The data was transformed from CSV to JSON and you can find it in the data folder in the backend section. The data was added to the database using the python script provided in the same folder as the data. The front-end part utilizes gridsome and Vue to display and filter the data coming from the API.

## Running the website

### 1. Running the backend
To run the backend you need Docker installed to run a MongoDB image. To run teh docker image use `docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo`
this command will keep the saved documents after you close the image so you can keep the destination after you add them. to run the .NET Core api simply hit F5 in the project. the API runs at https://localhost:7167/ . The API is ocnfigured to allow CORS from https://localhost:8080/ so that the front-end part can reach the api.
### 2. running the front end
To run the front-end portion of the app you need to `cd frontend` and run `grid some develop`.

### More detailed info about running and maintainning the website is provided in the prespective folders

## To Do List
1. Adding custom image per location using google photo places api
2. Polishing UI
3. Adding user authentication using firebase and deploying the website
4. Add recommendation based on previous locations visited using data analysis
