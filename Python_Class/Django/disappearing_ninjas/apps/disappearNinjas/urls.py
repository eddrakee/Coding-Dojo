from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$',views.index),
    url(r'^turtle$',views.showAll),
    url(r'^turtle/(?P<color>\w+)$', views.show)
    # url(r'^turtle/(?P<color>\w+)$', views.show, name = 'show'),
]



# from django.conf.urls import url
# from . import views
# urlpatterns = [
#     url(r'^ninjas$', views.index, name = 'index'),
#     url(r'^ninjas/(?P<ninja_color>\w+)$', views.show, name = 'show'),


 