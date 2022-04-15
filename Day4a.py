import numpy as np
import math


class bingo_field:
    def __init__(self):
        self.field = np.array([["00" for i in range(5)] for j in range(5)])
        self.hits = np.array([["  " for i in range(5)] for j in range(5)])
        #how many numbers are needed to win:
        self.win_count = 0
        self.status = 'no decission'
        self.score =None

        self.last_number =None
    def hit_field(self, x,y, value):
        self.hits[x][y] = 'x' 
        #self.win_count += 1
        self.status = self.check_win()
        if self.status =='win':
            self.last_number = value
            self.calc_score()
            

        return self.status
    
    
    def check_win(self):
        for i in range(5):
            #if self.hits[i] == np.array(['x' , 'x' , 'x' ,'x' ,'x' ]).astype(str):
            #compare_val =  np.array(['x' , 'x' , 'x' ,'x' ,'x' ], dtype='U')
            #print(compare_val)
            #print( self.hits[i])
            #if np.all( self.hits[i],compare_val):
            #    return 'win'
            if self.hits[0][i] =='x' and  self.hits[1][i]  =='x' and self.hits[2][i]  =='x' and self.hits[3][i]  =='x' and self.hits[4][i] =='x' :
                 return 'win'
            if self.hits[i][0]=='x' and  self.hits[i][1]  =='x' and self.hits[i][2] =='x' and self.hits[i][3]  =='x' and self.hits[i][4] =='x' :
                 return 'win'
        return 'loss'
    def print_all(self):
        print ("number of turns:", self.win_count)
        print("last pcked number:", self.last_number)
        print("score ", self.score)
        print(self.hits)
        print(self.field)

    def calc_score(self):
        score = 0
        for i in range(5):
            for j in range(5):
                if self.hits[i][j] != "x":
                    #print(self.field[i][j])
                    score = score + int(self.field[i][j])
        #print(score, "*", self.last_number)
        self.score = score * int(self.last_number) 




input_file = open('input4.txt', 'r')

commands =[]
line = None
while line != "\n":
    line=input_file.readline()
    comand = line.replace("\n", "")
    comand = comand.split(",")
    commands = commands + comand
commands= commands[:len(commands) -1]


field_list = []
### read  bingo fields ####################
field_count = 0
while True:
    f = bingo_field()
    line = None
    row_number = 0
    while True:
    
        line=input_file.readline()   
      
        field_row = line.replace("\n", "")
        field_row = line.split()

   
        if len(field_row)==0:
            break
        else:                
            f.field[row_number] = field_row
            row_number +=1
        
    field_count = field_count +  1      
    field_list.append(f) 
    if not line:
        break




###################file read finish
best_field = [-1]
fastes_win= math.inf
for f in range(len(field_list)):
    field = field_list[f]
    #print(field.field)
    for c in range(len(commands)):
        field.win_count +=1
        comand = int(commands[c])
        hit =  np.where(field.field == str(comand))
        #print(comand,hit[0], hit[1])
        if (len(hit[0]) > 0):
            #print(field.field[ hit[0][0] ][ hit[1][0] ] )
            check = field.hit_field(hit[0][0], hit[1][0], comand )
            if check == 'win':
                break
    #field.print_all()
    if field.status == 'win':
        print(field.win_count, f)
        if fastes_win > field.win_count:
            fastes_win = field.win_count
            best_field = f
    

field_list[best_field].print_all()
print("##############")
print(best_field, " ", field_list[best_field].score)
                    




