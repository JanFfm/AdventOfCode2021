windows = ['A', 'B', 'C', 'D']

left_win = windows[0]

scans = []
input_file = open('input1.txt', 'r')

for l in input_file:
    depth = l.split('\n')[0]
    if(len(depth) > 0):
            scans.append(int(depth))

scan_numer = len(scans)

counter = 0
scan_sequences = []
for i in range(scan_numer - 2):
    scan_sum = scans[i] + scans[i +1] + scans[i +2]
    scan_sequences.append(scan_sum)
    if i > 0 and scan_sum > scan_sequences[i-1]:
        counter +=1

print(counter)


