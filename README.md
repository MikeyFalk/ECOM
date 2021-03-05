## Project: Michael Jordan's 23 Delivery and Me

### We are deployed on Azure! 
- https://ecommerce-app20210228141734.azurewebsites.net/

### What is it?
- This application serves as an Ecommerce store where users are able to login once registering for an account. Upon their login, they will be shown a page with a navigation bar. Within our nav bar, there is a direct link to categories, products and our cart. Going to the product page will allow users to see a list categorized by meal type (vegan, vegetarian, etc.), when a specific meal is selected you will then be redirected to the product info page. In this page, there are details of the product along with an "add to cart" button. After adding to cart, users will be able to view the product in their cart, update the quanity and remove if no longer needed. 

### Admin features:
- As an admin, you will have a seeded role in the database that allows for creating, reading, updating and deleting categories and products.    
- Along with the admin role, we have created a "guest" role that is assigned to any user that registers for an account. In order to proceed with the cart, you have to be a registered and logged in user.

### Tools Used:
- C#
- ASP.Net Core
- MVC 
- Razor Pages
- Azure
- Entity Framework
- Identity

### Getting Started:
- You can clone down this repository to your local machine 
- https://MJ-MealKitDelivery@dev.azure.com/MJ-MealKitDelivery/Ecommerce-App/_git/Ecommerce-App.git

- Once this is cloned down to your local machine, you will need to run an "update-database" from your command line.
- After the steps above are completed, you will be able to build out the solution.

  
### Data Model
![Erd](./Assets/categoryerd.png)

### Authors:
- Mike Falk and Jordan Kidwell

### Contributors, Advisors, Guidance & Support:
- Ameilia Valdes
- John Cokos
- Bade Habib
- JP Jones
- Kjell Overholt
- David Dicken
