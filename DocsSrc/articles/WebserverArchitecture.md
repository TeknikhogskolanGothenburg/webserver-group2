# Webserver Architecture

* How are your webserver build? 
  -- create a listener to listen to the request
  -- obtain HttpListenerRequest and HttplistenerResponse object
  -- server receives request to 
      a)check if it is a valid request, if it is a bad request send message to client
      b)if it is a valid request, identify the content type, etc
  -- make resonse to the client
* What resources can the user access? = files in Content folder, session cookie counter and the sum of two inputs in dynamic page. 
* How does the server act in case of an error? = it returns Argument Exceptions and the program stops. 
