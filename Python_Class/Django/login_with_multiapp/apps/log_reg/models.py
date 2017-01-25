from __future__ import unicode_literals
from django.db import models
#we don't want the second or third app's imports here or it will make a loop
#import the second app's model!
import bcrypt
import re
import hashlib

# Create your models here.
class UserManager(models.Manager): # This is exclusive to User class
    def validate (self, postData1):
        #this method ensures that what the user inputs is valid
        regex_name = re.compile(r'^[a-zA-Z]{2,100}$') #{minum length, maximum length}
        EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
        error_arr = []
        # error = 0 #this is to check if everything below passes! It can also be used as a boolean
        if not regex_name.match(postData1['first_name']):
            error_arr.append("Please enter a valid name! It must be 2 characters long and have no numbers!")
        if not regex_name.match(postData1['last_name']):
            error_arr.append("Please enter a valid name! It must be 2 characters long and have no numbers!")
        if not EMAIL_REGEX.match(postData1['email']): #checks to see if the email was valid
            error_arr.append("Please enter a valid email!")
        if not postData1['password'] == postData1['confirm']: #if these don't match up
            error_arr.append("Your passwords do not match!")
        if self.email_exist(postData1): #take postData1 and pass it to the emailExist method
            error_arr.append("You have already registered with this email!")

        return error_arr #this will be passed to the register method in views.py

    def email_exist(self, postData):
    #if theres a record of our user entered email, then it will set to findEmail
        findEmail = User.objects.filter(email=postData['email'])
        if findEmail: #this line equates to: if findEmail has value, or is true
            return True #if it is true, the email already exists
        else:
            return False #if false, it will become registered   
    
    def register(self, postData):
        # this is essentially "user.object(user key first_name = entered in info in the html first_name field)"
        # we will only get to this if validate passes so we don't have to do more error checks
        self.create( #we want to create one row in Users that has all these fields so we keep it together
            first_name = postData['first_name'], 
            last_name = postData['last_name'], 
            email = postData['email'],
            password = bcrypt.hashpw(postData['confirm'].encode(), bcrypt.gensalt()) #bcrypt.gensalt is saying make the secret code!
        )
        #we don't return anything since we are simply adding data to Users and don't require anything in return
    
    def login_user(self, postData):
        user_info = self.filter(email=postData['email']) #find the User row that contains the entered email
        if not user_info: #if user_info is false...
            return False #if the email isn't there, get outta here!
        print ('- First instance of user_info -')
        print (user_info) #so we can see if it's the correct user we're talking about
        #user_info currently gives you an array which has a dictionary inside
        user_info = user_info[0] #traverse to the first index in the list
        print ('- Second instance of user_info -')
        print (user_info) #now we get object!
        pw_hash = user_info.password.encode() #this set pw_hash to equal the password for the user object we just printed in the terminal
        if pw_hash == bcrypt.hashpw(postData['password'].encode(), pw_hash): #the second pw_hash is being used to check if it matches the postData password
            return True
        return False #if it does not return True, it will return False which means the password doesn't match

        #this sets the session id
    def set_session(self, postData): #with this method, we will be retrieving an id and sending to our views.py
        #we already know that the inputed email exists, so now we want to find associated user info with the line below
        #Also, since we know that we will be getting a list with one item, we can skip setting this to find_user[0] and say .first() instead
        find_user = self.filter(email=postData['email']).first()
        return find_user.id #this sends returns the id value
       
        #this will get the session user data
    def set_user_session(self, session_id):
        #when you log in or register, an id for session gets created. We are now naming it session_id
        find_session_user = self.get(id=session_id) #.get will give you one object
        return find_session_user #to use this in my views.py, I must return it!


#we migrate if we change anything in the User class
class User(models.Model):
        first_name = models.CharField(max_length=45) #each field is an attribute
        last_name = models.CharField(max_length=45)
        email = models.CharField(max_length=100)
        password = models.CharField(max_length=100)
        created_at = models.DateTimeField(auto_now_add = True)
        updated_at = models.DateTimeField(auto_now = True)

        #don't forget to connect this to our UserManager!
        objects = UserManager()