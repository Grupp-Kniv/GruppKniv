# GruppKniv API specifikation

PRODUCT API SPECIFIKATION
![image](https://user-images.githubusercontent.com/75206855/207325593-0f1c6bd5-a868-4eb5-80f8-892e4248c95a.png)




ORDER API SPECIFIKATION

| Endpoint    | Parameter   | Method       | Request URL                     | Result                       |  
| ----------- | ----------- | ------------ | ------------------------------- | ---------------------------- | 
| api/orders  |             | GET          | https://localhost:7091/orders   | Returns all orders           | 
| api/order   | /{id}       | GET          | https://localhost:7091/order/1  | Returns the order with id 1  |
| api/order   |             | POST         | https://localhost:7091/order    | Creates a new order          |            


ShoppingCart API Specifikation

| Endpoint                          | Parameter   | Method       | Request URL                                               | Result                       |  
| --------------------------------- | ----------- | ------------ | --------------------------------------------------------- | ---------------------------- | 
| api/shoppingCart                  |    {id}     | GET          | https://localhost:7282/api/shoppingCart/{id}              | Returns a shoppingCart       | 
| api/shoppingCart/AddShoppingCart  |             | POST         | https://localhost:7282/api/shoppingCart/AddShoppingCart   | Create a shoppingCart        |
| api/shoppingCart                  |             | POST         | https://localhost:7282/api/shoppingCart/UpdateShoppingCart| Update a shoppingCart        |  

