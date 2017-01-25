from __future__ import unicode_literals

from django.db import models
from ..posts.models import Post #which post it is
from ..log_reg.models import User
# Create your models here.

class Comment(models.Model):
    content = models.TextField()
    user = models.ForeignKey(User, related_name = "posted") #make a different related name than the one in the posts app
    post = models.ForeignKey(Post, related_name = "commented")  #make a different related name than the one in the posts app
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)  