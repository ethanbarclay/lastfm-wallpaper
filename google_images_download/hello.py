#!/usr/bin/env
 
import sys
 
def main():
    print('Hello')
    if len(sys.argv) >=3:
        x = sys.argv[1]
        y = sys.argv[2]
        # print concatenated parameters
        print(x+y)
 
 
if __name__=='__main__':
    main()