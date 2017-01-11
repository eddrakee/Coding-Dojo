"""program should display what the grade is for a particular score. Here is the grade table:

Score: 60 - 69; Grade - D
Score: 70 - 79; Grade - C
Score: 80 - 89; Grade - B
Score: 90 - 100; Grade - A"""

def whatGrade():
    for count in range(1,11):
        result = raw_input("Please enter your test score: ")
        try:
            score = int(result)
        except ValueError:
            print "Please enter a number"
        print "Scores and Grades"
        if  60>= score <= 69:
            print "Score:", result + "; Your grade is D"
        elif 70 <= score <= 79:
             print "Score:", result + "; Your grade is C"
        elif 80 <= score <= 89:
            print "Score:", result + "; Your grade is B"
        elif 90 <= score <= 100:
            print "Score:", result + "; Your grade is A"
        
whatGrade()
print "End of program. Bye!"

"""
ANSWER:
from random import randint

print "Scores and Grades"
for count in range(0, 10):
	score = randint(70, 100)

	if(score <= 70):
		grade = "D"
	elif(score <= 80):
		grade = "C"
	elif(score <= 90):
		grade = "B"
	else:
		grade = "A"

	print "Score: %d; Your grade is %s" %(score, grade)

print "End of program. Bye!"
"""