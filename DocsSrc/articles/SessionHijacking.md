# Session hijacking
Describe the cookie vulnerability called "Session hijacking" which the archicture of this webserver contains. Both the problem and a possible solution:

* Problem = Exploitation of a valid computer session—sometimes also called a session key—to gain unauthorized access to information or services in a computer system. 
In particular, it is used to refer to the theft of a magic cookie used to authenticate a user to a remote server. 
It has particular relevance to web developers, as the HTTP cookies[1] used to maintain a session on many web sites can be easily stolen by an attacker using an intermediary computer or with access to the saved cookies on the victim's computer (see [HTTP cookie theft](https://en.wikipedia.org/wiki/HTTP_cookie#Cookie_theft_and_session_hijacking)).

* Solution = The best way to prevent session hijacking is enabling the protection from the client side. 
It is recommended that taking preventive measures for the session hijacking on the client side. The users should have efficient antivirus, anti-malware software, and should keep the software up to date.
See more on [interserver.net](https://www.interserver.net/tips/kb/session-hijacking-prevent/)