from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^courses$', views.create_course),
    url(r'^courses$', views.print_course),
    url(r'^remove/(?P<id>\d+)$', views.delete),
]