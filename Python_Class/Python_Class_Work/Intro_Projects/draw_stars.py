#Part 1
# Create a function called  draw_stars() that takes a list of numbers and prints out  *.

def draw_stars(list):
    for idx, val in enumerate(list):
        print "*" * val
draw_stars([1,5,1,4])

#Part 2
"""
Modify the function above. Allow a list containing integers and strings to be passed to
 the  draw_stars() function. When a string is passed, instead of  displaying *, display 
 the first letter of the string according to the example below. You may use the .lower() string method for this part.
 """

def draw_stars(list):

    for idx, val in enumerate(list):

        if (val >= 0 and val <= 9):
            print "*" * val
        else:
            print val[0].lower() * len(val)
draw_stars([1, "elise", 1, 4])


"""
ANSWERS
 
stars.py
# Part I
x = [4,6,1,3,5,7,25]
def draw_starsI(num_list):
    for num in num_list:
        output = ''
        for i in range(num):
            output += '*'
        print output 

draw_starsI(x)

# Part II
y = [4,'Tom',1,'Michael',5,7,'Jimmy Smith']
def draw_stars2(my_list):
    for item in my_list:
        output = ''
        if type(item) is int:
            for i in range(item):
                output += '*'
        elif type(item) is str:
            first_letter = item[0].lower()
            for i in range(len(item)):
                output += first_letter
        print output

draw_stars2(y)
"""
