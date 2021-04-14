This source base allows someone to re-create a simple Angular 9 frontend app
that talks to a .Net Core 3.1 API controller backend.  

The frontend does nothing more than provide a text box to type in an HTTP string
and then apply that string (button) to send to the backend.  

Note that a kong-proxy ingress (used as API-Gateway) service sits in between the frontend and 
backend to redirect the call to the backend.  The following are the steps to reproduce this.


1) We assume you will know how to run kubernetes and are on some type of kubernetes cluster
   (AWS, Google (GKE), Linode, or minikube).  It is also assumed that you are familiar with 
   kubectl commands and have kubectl and helm installed in your encironment.

2) First install kong-proxy ingress with this command: 
    
   kubectl apply -f https://bit.ly/k4k8s

3) This will create a kong-proxy service.

4) Install frontend app using the privided manifest file 'frontend-simple.yaml' in the Kubernetes folder.
   Note that will use our public image from our DockerHub 'scubagrant60/apitest-images:frontend'.  This
   image has been built from the source code in the Frontend folder.

   kubectl apply -f frontend-simple.yaml

   If you want to make changes to code and then use your own image, then follow these steps:
   
   a) Compile our angular frontend by running the command 'ng build --prod'  from inside our Frontend 
      folder.  This presumes you have Node/Angular on your machine and can build Angular applications.
   b) Once the 'ng' command has run, then build a docker image with our Dockerfile provided in our Frontend 
      folder.  
   c) The will need to run our manifest file: 'frontend-simple.yaml' and change the image in the Deployment
      section to the image you just created in steb 4b above.

5) Install backend app using the privided manifest file 'backend-simple.yaml' in the Kubernetes folder.
   Note that will use our public image from our DockerHub 'scubagrant60/apitest-images:backend'.  This
   image has been built from the source code in the Backend folder.
   If you want to make changes to code and then use your own image, then follow these steps:
   
   kubectl apply -f backend-simple.yaml

   a) Compile our .Net Core backend by running the command 'ng build --prod'  from inside our Backend 
      folder.  This presumes you have Visual Studio 2019 on your machine and can build .Net Core 3.1 applications.
   b) Once the compiled the code, then build a docker image with our Dockerfile provided in our Backend 
      folder.  
   c) The will need to run our manifest file: 'backend-simple.yaml' and change the image in the Deployment
      section to the image you just created in steb 5b above. 

6) Next we need to install the kong api-gateway that will act to redirect http calls to the appropriate backend service.  
   While we only have one service, 'test', more paths can be created in the api-gateway.

   kubectl apply -f kong-gateway-simple.yaml



