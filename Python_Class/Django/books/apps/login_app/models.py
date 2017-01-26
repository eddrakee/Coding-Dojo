from __future__ import unicode_literals
import bcrypt
import hashlib
import re

from django.db import models

# Create your models here.
class UserManager(models.Manager):
    def register(self, postData):
        self.create( 
            first_name = postData['first_name'], 
            last_name = postData['last_name'], 
            email = postData['email'],
            password = bcrypt.hashpw(postData['confirm'].encode(), bcrypt.gensalt()) 
        )

class User(models.Model):
    first_name = models.CharField(max_length=45) #each field is an attribute
    last_name = models.CharField(max_length=45)
    email = models.CharField(max_length=100)
    password = models.CharField(max_length=100)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    #don't forget to connect this to our UserManager!
    objects = UserManager()