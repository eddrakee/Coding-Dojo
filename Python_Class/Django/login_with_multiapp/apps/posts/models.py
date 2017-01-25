from __future__ import unicode_literals

from django.db import models
from ..log_reg.models import User #don't forget to import our first app's model! Put this in both!
#from ..firstApp.models import class

# Create your models here.
class PostManager(models.Manager):
    pass




#make your POST models!
class Post(models.Model):
    content = models.TextField()
    user = models.ForeignKey(User, related_name = "posted_by")
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    objects = PostManager()
    #since UserManager is inhereted from our User class, we will have access to 

#we are going to make a third app for our comments