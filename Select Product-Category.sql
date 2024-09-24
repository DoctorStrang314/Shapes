Use Task 
Select ProductName,CategoryName From [Product-Category]
join Products on [Product-Category].ProductId = Products.ProductId
join Categores on [Product-Category].CategoryId =Categores.CategoryId