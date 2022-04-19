
using AppTraining;

ObjectClassOne nObj = new ObjectClassOne();
nObj.sName = "Test";
string sNewName = nObj.sName;//setting local variable to ObjectClassOne's sName variable
Console.WriteLine(sNewName);//print the local variable
Console.WriteLine(ObjectClassOne.csName);//printing the constent
nObj.TestDoThings("Test 2 meow", "Test 3");//method

mySecondClass msc = new mySecondClass();
msc.authority = Authority.hire;
msc.sName = "though mySecondClass";
msc.TestDoThings("meow 1","2 meow");
msc.thist();