#! /usr/bin/bash

select iMain in loop_till_20 input_1_to_20 inputs loop_over exit
do
    case $iMain in
        loop_till_20) #loop 1-20 and output 
            iInput=1
            until [ $iInput -ge 21 ]
            do 
                if (($iInput % 5 == 0)) && (($iInput % 3 == 0))
                then 
                    echo "$iInput = fizzbuzz"
                elif (($iInput % 3 == 0))
                then 
                    echo "$iInput = fizz"
                elif (($iInput % 5 == 0))
                then 
                    echo "$iInput = buzz"
                else
                    echo " $iInput =  "
                fi
                iInput=$(( iInput+1 ))
            done
        ;;
        input_1_to_20) #Get input from user for 1-20
            read -p "Input a positve number from 1-20: " iInput
            if (($iInput <= 0))||(($iInput >= 21))
            then
                echo "Sorry! thats not a valid input!"
            elif (($iInput % 5 == 0)) && (($iInput % 3 == 0))
            then 
                echo "$iInput = fizzbuzz"
            elif (($iInput % 3 == 0))
            then 
                echo "$iInput = fizz"
            elif (($iInput % 5 == 0))
            then 
                echo "$iInput = buzz"
            else
                echo " $iInput =     "
            fi
            iInput=$(( iInput+1 ))
        ;;
        inputs) #Get input from user 
            read -p "Input a number: " iInput
            
            if (($iInput % 5 == 0)) && (($iInput % 3 == 0))
            then 
                echo "$iInput = fizzbuzz"
            elif (($iInput % 3 == 0))
            then 
                echo "$iInput = fizz"
            elif (($iInput % 5 == 0))
            then 
                echo "$iInput = buzz"
            else
                echo " $iInput =     "
            fi
            iInput=$(( iInput+1 ))
        ;;
        loop_over)
            read -p "loop thought 1 - " iLoop
            iInput=1
            iLoop=$(( iLoop+1 ))
            until [ $iInput -ge $iLoop ]
            do 

                if (($iInput % 5 == 0)) && (($iInput % 3 == 0))
                then 
                    echo "$iInput = fizzbuzz"
                elif (($iInput % 3 == 0))
                then 
                    echo "$iInput = fizz"
                elif (($iInput % 5 == 0))
                then 
                    echo "$iInput = buzz"
                else
                    echo " $iInput =  "
                fi
                iInput=$(( iInput+1 ))
            done
        ;;
        exit)
            echo "Bye!"
            break
        ;;
        *)
            echo "Error: Please try again (1-5)"
        ;;
    esac
done


