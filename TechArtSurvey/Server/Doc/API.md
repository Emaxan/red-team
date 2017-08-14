# Server API #

### UsersController ###
* Actions:
  * Get all users:  
  	Method: GET  
	URL: http://localhost:13695/api/users  
	Params:  
	Response: Array of user objects in JSON  
	Headers:  
		1.Authorization: bearer access_token_hash,  
		2.Accept: application/json,  
		3.Content-Type: application/json  
		
			 
  * Get user by id:  
  	Method: GET  
	URL: http://localhost:13695/api/users/1  
	Params:   
	Response: User obj with id==1 in JSON  
	Headers:   
		1.Authorization: bearer access_token_hash,  
	    2.Accept: application/json,  
		3.Content-Type: application/json  
	
	
  * Check by email if user already exists:  
  	Method: GET  
	URL: api/Users?email=user@user.user  
	Params:  
		1.email  
	Response: User obj with email==user@user.user in JSON  
	Headers:    
	    1.Accept: application/json,  
		2.Content-Type: application/json  

			 
  * Update user by id:  
  	Method: PUT  
	URL: http://localhost:13695/api/users/1  
	Params:  
		1.Id  
		2.UserName  
		3.Email  
		4.Password  
		5.[RoleDto]  
	Response:  
	Headers:   
		1.Authorization: bearer access_token_hash,  
		2.Accept: application/json,  
		3.Content-Type: application/json  
	
	
  * Get user by id:  
  	Method: DELETE  
	URL: http://localhost:13695/api/users/  
	Params:   
		1.Id  
	Response:  
	Headers:  
		1.Authorization: bearer access_token_hash,  
	    2.Accept: application/json,  
		3.Content-Type: application/json  
	
	
### AccountController ###
* Actions:  
  * Add user in DB:  
  	Method: POST  
	URL: http://localhost:13695/api/account/signup  
	Params:   
		1.UserName  
		2.Email  
		3.Password  
		4.[RoleDto]  
	Response: User obj in JSON  
	Headers:  
	
	
### Token ###
* Actions:  
  * Get all users:  
  	Method: GET  
	URL: http://localhost:13695/token  
	Params:   
		1.grant_type  
		2.[UserName (if grant_type == password)]  
		3.[Password (if grant_type == password)]  
		4.[refresh_token (if grant_type == refresh_token)]  
	Response: Access_token, access_token expires, refresh_token  
	Headers:   
		1.Content-Type: application/x-www-form-urlencoded  
		2.Accept: application/x-www-form-urlencoded  

