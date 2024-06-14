# Sultan Nassar EmedicineServer 

This is a simple fullstack project: React as afrontend and ASP.NET API as backend that allows you to create, Edit Delete and display products. It provides a user-friendly interface for entering order information and generates a visually appealing product cart.

## Features

- Input fields for FirstName,LastName, Email, Password.
- Upload a profile image for account, and products.
- A Cart that will show products which you have bought, and give you the option to place orders.
- An Order list that will show your orders which you have purchased.
- Pages to manage Allproduct by CRUD actions and buying options by add to Cart.
- Search Bar and filter option in products page which help you to find the specific product you're looking for.
- every Order which you have purchased has a status and it is waiting for admin approved, reject...etc

## Installation
<p>
1. install git on your computer from the link https://git-scm.com/downloads <br>
2.  Clone the repository to your local machine: <br>
   
   ###for backend side

<p> Open a new VS (for backend side) in a new folder <br>  </p> 
<p> at the sidebar above click on Git, then Clone repository.  <br>  </p> 
   <br>
   <p> pick a location folder and then paste the path.  </p> 
<br>
   put this on the URL of Git
   https://github.com/sultan-nassar/Emedicine-Server.git  <br>

<p>
<strong> <br>
<br>
</p>

###for frontend side
<p> Open a new VS (for frontend side) in a new folder <br>  </p> 
<p> Open the terminal <br>  </p> 
   <br>
    clone the git link:   https://github.com/sultan-nassar/CardAppFinalProject.git <br>
 <br>
<p>
<strong> at the terminal</strong> you have to navigate to the directory: <br>
  Cd server-card-sultan <br>
<br>
</p>



## Usage   

1. Open your web browser and visit `http://localhost:3000` to access the application.
2. New User? Go to http://localhost:3000/registration and Enter your personal information in the input fields provided to register the website. 
3. Already have a user? Go to http://localhost:3000/login and enter your user and password.
   <br>
4. <strong> first of all, you must login as an <strong>admin</strong> so you can add medicine or supplements with image, edit or delete medicines, approve user's orders status and more...</strong>
   To login as an admin you must write:
   #### <strong> email: admin@gmail.com </strong>
   #### <strong> password: admin123 </strong>
   
  <strong>after login as an admin you can visit:</strong>
- Medicine Master: her you can add, edit, delete supplements and medicines for your site.
- User List: her you can see User's List, also you can see all the users whith there Status.
- Order List: her you can see order List, also you can update the status of the regular user's order to approved or rejected....
- Products: her you can see all the Products and you can also use filter or search to look for a specific product.

5. <strong> second of all, you should login as a <strong>regular user</strong>.
   To login as a regular user you must write:
   #### <strong> email: test@gmail.com </strong>
   #### <strong> password: 1234567 </strong>
   
   OR you can make a register before her: http://localhost:3000/registration
   
  <strong>after login as a regular user you can visit:</strong>
- profile: her you can see your personal data.
- Products: her you can see all the products which the Admin has been added to the site, so you can buy suitable quantity from each product.
- My Orders: her you can see your orders, also you can see the status of the order if has been approved or rejected by the admin....
- Cart: her you can see your Cart, also you can delete product or place order, so the admin can see this and he will update the status of the order per regular user.




## Customization

You can customize the project to fit your specific needs:

- Modify the layout and styling in the `src /components` directory.
- Extend the functionality by adding new features or components.




## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request on the project's GitHub repository.

## License

This project is licensed under the [MIT License](LICENSE). Feel free to use and modify it for your own purposes.


## Acknowledgements

- This project was inspired by the need for a simple and intuitive E-Commerce app tool.
- The React framework and its ecosystem made it possible to develop this application quickly and efficiently.


## Contact

If you have any questions, suggestions, or feedback, please feel free to contact the project maintainer at sultannassar11@gmail.com.

Happy designing!

Sultan
