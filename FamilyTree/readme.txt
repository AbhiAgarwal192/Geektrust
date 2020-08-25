This solution is built on .net core 3.1.
To build the solution, run the below command:
dotnet build -o geektrust.

To run the solution run the following command:
dotnet geektrust/geektrust.dll <Absolute path of test file>

There are no third party libraries being used other than standard dotnet core framework libraries.

Only below input formats are accepted:
ADD_CHILD <mother's name> <child name> <gender>
GET_RELATIONSHIP <child name> <relationship>

Also only the below relationship types are handled:
Siblings, Son, Daughter, Paternal-Uncle, Paternal-Aunt, Maternal-Uncle, Maternal-Aunt, Sister-In-Law, Brother-In-Law.

Assumptions:

1) Since we can only add children under a mother node, all the children information are present only under mother node.

2) Since it is given that names are unique, no checks are added to ensure the same.