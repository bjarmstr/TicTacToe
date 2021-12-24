# Code Challenge Tic-Tac-Toe

##  Create Player  

 https://localhost:34024/api/player
- Players must be created before a game is started  
- default guest was not implemented in this version  
  {  
    "name": "string"  
  }

##  Endpoint 1 Create Game

https://localhost:34024/api/game  
- 2 Players are require for a game
- in this implementation a start player is also selected  
  {  
  "playerIds": ["Guid","Guid"],  
   "startPlayer": "Guid"  
   }

##  Endpoint 2 Place a Move  

https://localhost:34024/api/game/move
- the game board locations are defined as an int 0-8  
- it must be the player's turn for them to enter a location
-  0 | 1 | 2  
 3 | 4 | 5   
 6 | 7 | 8  
 {  
    "gameId": "Guid",  
    "player": "Guid",  
    "location": int  
}  

##  Endpoint 3  Games in Progress

https://localhost:34024/api/game/inprogress?pageIndex=1&pageSize=10  
-  in the query string note how many games you wish to view at once  
-  a pageIndex of 1 is the first page  

## Final Question

Question:  What is the appropriate OAuth/OIDC grant to use for a web application using a SPA and why?

Answer:  An authorization grant with Proof Key for Code Exchange (PKCE) is now the recommended method over the implicit flow.  The implicit flow has been used for SPAs because secrets cannot be securely stored because the source code is all available to the browser. PKCE solves some redirection threats that the implicit flow has. PKCE solves this by using indirection on the backchannel instead of redirection on the front channel. 
  



