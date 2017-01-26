from __future__ import unicode_literals
import bcrypt
import hashlib
import re

from django.db import models

# Create your models here.
class BookManager(models.Manager):
    def add_book(self, postData):
        self.create( 
            author = postData['author'], 
            title = postData['title'],
            new_author = postData['new_author'],
        )
        pass

class Book(models.Model):
    author = models.CharField(max_length=100)
    title = models.CharField(max_length=100)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    #don't forget to connect this to our UserManager!
    objects = BookManager()