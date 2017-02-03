from __future__ import unicode_literals
import bcrypt
import hashlib
import re

from django.db import models

# Create your models here.
class UserManager(models.Manager):
    def register(self, postData):
        new_user = self.create( 
            first_name = postData['first_name'], 
            last_name = postData['last_name'], 
            email = postData['email'],
            password = bcrypt.hashpw(postData['confirm'].encode(), bcrypt.gensalt()) 
        )
        return(new_user)
    
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


class User(models.Model):
    first_name = models.CharField(max_length=45) #each field is an attribute
    last_name = models.CharField(max_length=45)
    email = models.CharField(max_length=100)
    password = models.CharField(max_length=100)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    #don't forget to connect this to our UserManager!
    objects = UserManager()