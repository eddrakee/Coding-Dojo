from __future__ import unicode_literals

from django.db import models

#Our new manager!
#No methods in our new manager should ever catch the whole request object with a parameter!!! (just parts, like request.POST) otherwise it will be too large
class UserManager(models.Manager):
    def login(self, postData):
        pass
#self.get(first_name=postData['firstname], last_name=[]) how to get id? then set session for login?


    def register(self, postData):
        #postData is a dictionary that come from request.POST(the stuff we entered in in our user.objects.register)
        print (postData, "now in user manager")
        user = self.create(first_name=postData['first_name'], last_name=postData['last_name'], password=postData['password'])
        #We had to break these into pieces to pass them into the self.create method. we initally passed them int
        #as user.objects.create(postData) (this didnt work)
        print self.all()
        #the same thing as saying User.objects.all()
        #do not pass the whole request means make sure you put in request.POST as the paramater NOT only "request"
        #that will give me too much extra shit
        return (user, "this is what was returned")

        
class User(models.Model):
    first_name = models.CharField(max_length=45)
    last_name = models.CharField(max_length=45)
    password = models.CharField(max_length=100)
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)
    # *************************
    # Connect an instance of UserManager to our User model overwriting 
    # the old hidden objects key with a new one with extra properties!!!
    objects = UserManager()
    #he calls this userMnager, when i tried to use this it was wrong, upon using objects which i overwrote to be user manager i ended up now susscessfully creating a user
    