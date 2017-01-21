from django.conf.urls import url
from . import views


urlpatterns = [
    url(r'^$', views.generateWord),
    url(r'^generate$', views.create),
    url(r'^clear$', views.reset)
]
