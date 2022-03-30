#! /usr/bin/bash

select iMain in loops inputs loop_over exit
do
    case $iMain in
        loops)
            iC=1
            until [ $iC -ge 21 ]
            do 

                if (($iC % 5 == 0)) && (($iC % 3 == 0))
                then 
                    echo "$iC = fizzbuzz"
                elif (($iC % 3 == 0))
                then 
                    echo "$iC = fizz"
                elif (($iC % 5 == 0))
                then 
                    echo "$iC = buzz"
                else
                    echo " $iC =  "
                fi
                iC=$(( iC+1 ))
            done

        ;;
        inputs)
            read -p "Input Int: " iC
            if (($iC % 5 == 0)) && (($iC % 3 == 0))
            then 
                echo "$iC = fizzbuzz"
            elif (($iC % 3 == 0))
            then 
                echo "$iC = fizz"
            elif (($iC % 5 == 0))
            then 
                echo "$iC = buzz"
            else
                echo " $iC =     "
            fi
            iC=$(( iC+1 ))
        ;;
        loop_over)
            read -p "Input number of time loop Int: 1 to " iLoop
            iC=1
            iLoop=$(( iLoop+1 ))
            until [ $iC -ge $iLoop ]
            do 

                if (($iC % 5 == 0)) && (($iC % 3 == 0))
                then 
                    echo "$iC = fizzbuzz"
                elif (($iC % 3 == 0))
                then 
                    echo "$iC = fizz"
                elif (($iC % 5 == 0))
                then 
                    echo "$iC = buzz"
                else
                    echo " $iC =  "
                fi
                iC=$(( iC+1 ))
            done
        ;;
        exit)
            echo "Bye!"
            break
        ;;
        *)
            echo "Error: Please try again"
        ;;
    esac
done


