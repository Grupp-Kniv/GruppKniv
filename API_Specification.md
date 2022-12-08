## Specification

## Models:

¤ Product:
| | | |
| ----------- | ------------ | ------------ |
| [Key] | int | ProductId |
| [Req] | String | Name |
| [Range] | double | Price |
| | String | Description |
| | string | Image |

¤ Order:
| | | |
| ----------- | ------------ | ------------ |
| [Key] | int | OrderId |
| | int | Count |
| | Product | Product |
| | int | ProductId |
| | User | User |
| | int | UserId |

¤ ShoppingCart:
| | | |
| ----------- | ------------ | ------------ |
| [Key] | int |ShoppingCart |
| | List<Product>| Products |
| | double | TotalCart |

## API Spec:

¤ product:

| HTTP Method | Path          | Request Body | Response Body    | QueryParams | ResponseCode | Description      |
| ----------- | ------------- | ------------ | ---------------- | ----------- | ------------ | ---------------- |
| 1. Post     | /product      | Product      | OK Message       | \*\*        | Ok - BR      | Save a product   |
| 2. Get      | /product      | \*\*         | List of products | \*\*        | Ok - NF      | Return a list    |
| 3. Get      | /product/{Id} | \*\*         | product          | \*\*        | Ok - NF      | Return a product |

¤ Order:

| HTTP Method | Path        | Request Body | Response Body | QueryParams | ResponseCode | Description    |
| ----------- | ----------- | ------------ | ------------- | ----------- | ------------ | -------------- |
| 1. Post     | /Order      | Order        | OK Message    | \*\*        | Ok - BR      | Save a Order   |
| 2. Get      | /Order      | \*\*         | List of Order | \*\*        | Ok - NF      | Return a list  |
| 3. Get      | /Order/{id} | \*\*         | Order         | \*\*        | Ok - NF      | Return a Order |

¤ ShoppingCart:

| HTTP Method | Path               | Request Body | Response Body | QueryParams | ResponseCode | Description           |
| ----------- | ------------------ | ------------ | ------------- | ----------- | ------------ | --------------------- |
| 1. Post     | /ShoppingCart      | ShoppingCart | OK Message    | \*\*        | Ok - BR      | Save a ShoppingCart   |
| 2. Get      | /ShoppingCart      | \*\*         | List          | \*\*        | Ok - NF      | Return a list         |
| 3. Get      | /ShoppingCart/{id} | \*\*         | ShoppingCart  | \*\*        | Ok - NF      | Return a ShoppingCart |
