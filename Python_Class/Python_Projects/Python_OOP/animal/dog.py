#Now, create another class called Dog that inherits everything that the Animal does and has, but 1) have the default health be 150 and 2) add a new method called pet, which when invoked, increase the health by 5. Have the Dog walk() three times, run() twice, pet() once, and have it displayHealth().

from animal import Animal #from folder, import file

class Dog(Animal):
    def __init__(self):
        super(Dog, self).__init__("Joey", self)
        self.health = 150
    
    def pet(self):
        self.health += 5
        return self
Dog1 = Dog()
print "- From Dog File -"
Dog1.walk().walk().walk().run().run().pet().displayHealth()
