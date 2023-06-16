# AnimalsOnPages
ASP.Net project on RazorPages with CRUD service. RAM Repository. 2 language localization. MStest of Service.
</br>
</br>
<h3>Idea</h3>
The idea was the next:</br>
<ul>
<li>Each zoo has address, but address can be without zoo. The relationship is one-to-one.</br>
So, we create address, then we create zoo and pick the address.</li>
<li>Animal (means specie) can be in few zoo and zoo can shows few animals (means species).</br>
But animal can be without zoos and zoo can be without animals. The relationship is many-to-many.</br>
When we create animal we can add zoos and vice versa.</li>
</ul>
</br>
<h3>Pages</h3>
Website about animals with 6 Pages on MenuTab: Animals (Index), Add animal, Zoos, Add zoo, Addresses and Add address.</br>
<h4>Animals Pages</h4>
Each animal that shows on <strong>Index</strong> page wrapped in card and has 2 buttons: Find out more and Delete.</br>
Button "Find out more" redirect us to additional page Animal Details.</br>
With "Delete" button we can delete animal from repository. When we delete animal we don't delete any zoo.</br>
Additional page <strong>Animal Details</strong> shows us only one card with same animal that button was pressed.</br>
Also, Animal Details page shows us the information in which zoo we can see this animal.</br>
Card of zoo contains both name of zoo and address of zoo and button More info that redirects us to Zoo Details page.</br>
There are 2 buttons: Back to animals and Update animals, on page Animal Details.</br>
Button "Back to animals" redirects us to Index-page.</br>
Button "Update animal" links us to Add animal page but with id of animal that has been updated.</br>
Page <strong>Add animal</strong> is a form with inputs according to animal fields.</br>
Depends on button that was pressed before redirecting, page show us blank form or filled form.</br>
After pressing "Add animal" button on MenuTab, form will be blank with:</br>
<ul>
<li>Readonly id input shows us 0. Input doesn't affect anything.</li>
<li>Animal Class default checked value "Mammal".</li>
<li>Sex default checked value "Man".</li>
<li>Rank default checked value "Carnivorous".</li>
</ul>
After pressing "Update animal" on Animal Details page, all form inputs will be filled according to the data of animal.</br>
There are 2 buttons: Create (or Update) and Cancel, on page Add animal.</br>
Animals pages has 2 language localization: English and Ukrainian.</br>
</br>
<h4>Zoo Pages</h4>
Each zoo that shows on <strong>Zoos</strong> page wrapped in card and has 2 buttons: More info and Delete.</br>
Button "More info" redirect us to additional page Zoo Details.</br>
With "Delete" button we can delete zoo from repository. When we delete zoo we don't delete any animal and/or adress from repository.</br>
Additional page <strong>Zoo Details</strong> shows us only one card with same zoo that button was pressed.</br>
Also, Zoo Details page shows us the information what animals can be seen in this zoo.</br>
Card of animal contains information about animal and button Find out more that redirects us to Animal Details page<.br>
There are 2 buttons: Back to zoos and Update zoo, on page Zoo Details.</br>
Button "Back to zoos" redirects us to Zoos-page.</br>
Button "Update zoo" links us to Add zoo page but with id of zoo that has been updated.</br>
Page <strong>Add zoo</strong> is a form with inputs according to zoo fields.</br>
Depends on button that was pressed before redirecting, page show us blank form or filled form.</br>
After pressing "Add zoo" button on MenuTab, form will be blank with:</br>
<ul>
<li>Readonly id input shows us 0. Input doesn't affect anything.</li>
<li>Address default checked value will be first from the list of available addresses.</li>
</ul>
After pressing "Update zoo" on Zoo Details page, all form inputs will be filled according to the data of zoo.</br>
There are 2 buttons: Create (or Update) and Cancel, on page Add zoo.</br>
Zoo pages has no any additional language localization. Available only one language - English.</br>
</br>
<h4>Address Pages</h4>
Each zoo that shows on <strong>Addresses</strong> page wrapped in card and has 2 buttons: More info and Delete.</br>
Button "More info" redirect us to additional page Address Details.</br>
With "Delete" button we can delete address from repository. When we delete address we also delete zoo in relationship from repository.</br>
Additional page <strong>Address Details</strong> shows us only one card with same address that button was pressed.</br>
There are 2 buttons: Back to addresses and Update address, on page Address Details.</br>
Button "Back to addresses" redirects us to Addresses-page.</br>
Button "Update address" links us to Add address page but with id of address that has been updated.</br>
Page <strong>Add address</strong> is a form with inputs according to address fields.</br>
Depends on button that was pressed before redirecting, page show us blank form or filled form.</br>
After pressing "Add address" button on MenuTab, form will be blank with id input that shows us 0. Input doesn't affect anything.</br>
After pressing "Update zoo" on Zoo Details page, all form inputs will be filled according to the data of address.</br>
There are 2 buttons: Create (or Update) and Cancel, on page Add address.</br>
Address pages has no any additional language localization. Available only one language - English.</br>
</br>
<h3>Services</h3>
AnimalsService, ZoosService and AddressesService provides us CRUD methods: GetAll, Get, Add, Update, Delete.</br>
Services works with repositories that have DbContext with Entity Framework connection to SQL Server.</br>
Local DbContext has 4 DbSet: Animals, Zoos, Addresses and ZooAnimal that contains connections between zoos and animals.</br>
DbSet animals can't be created (Animal is abstract class) without creating additional entities Amphibia, Mammal and Reptile.</br>
At the start of the site's work created 2 migrations: InitialCreate and DBSeeding. So SQL Servers has to be updated before website starting to work.</br>
Local DbContext on the start has nexts data seed: 5 addresses, 5 zoos and 5 animals (2 of Mammal, 2 of Reptile and 1 of Amphibia).</br>
DbSet ZooAnimal seeded with 12 random records.</br>
Requests in services:</br>
<ul>
<li><strong>GetAll</strong> request returns list of corresponding class. Nothing special.</li>
<li><strong>Get</strong> request returns object of corresponding class with defined id, but, if id is null or is absent in the repository method returns null.</li>
<li>In <strong>Add</strong> request, service validate everything before request will be passed to repository.</br>
Id in this request will be placed automatically by Entity Framework.</br>
<ul>
<li> Object of <strong>Animal class</strong>.<br>
String classOfAnimal are required in this request, so if it null or not one of 3 available, the request will be rejected.</br>
Fields Name and Sound are required, so if they are null the request will be rejected.</br>
If field Name is already in the list of animals, request will be rejected.</br>
If fields Sex and Rank service receive as null, they will be defined "Man" and "Carnivorous" respectively.</br>
Field CoverColor will be filled automatically with "No Specified", if we leaved it blank.</br>
Add method of Service accepts AnimalDto object that has fields Id, Name, Sex, Rank, Sound, CoverColor.</br>
Then Service create Animal according to classOfAnimal, the string that also accepts Service.</br>
Other class fields will be filled to respectively of class of animal.</br>
If list of zoos passed to repository empty or null so animal will be created with empty ICollection<Zoo>.</li>
If list of zoos passed to repository not empty so primarily will be created animal with empty ICollection<Zoo> and then List will be inserted inside.</li>
<li> Object of <strong>Zoo class</strong>.<br>
Field Name is required so if it is null or empty the request will be rejected.</br>
If field Address is is null or empty request will be rejected. By default form of zoo is picking first Address from the list of addresses.</br>
If list of animals passed to repository empty or null so zoo will be created with empty ICollection<Animal>.</li>
If list of animals passed to repository not empty so primarily will be created zoo with empty ICollection<Animal> and then List will be inserted inside.</li>
<li> Object of <strong>Address class</strong>.<br>
Field Postal Code is not required, but if they filled it has to be unique or otherwise request will be rejected.</br>
Fields Country, City and Street are required, so if they are null the request will be rejected.</br>
Field Building is required and can't be null or less then 1 or more then 10000, otherwise request will be rejected.</li>
</ul>
</li>
<li>In <strong>Update</strong> request, service validate everything before request will be passed to repository.</br>
Id in this request will be checked if it already in the DbSet of corresponding class. If no - the request will be rejected.</br>
Other fields are validating according to Add request.</br>
Field Name of objects of Animal or Zoo classes, by exception of Add request, can be the same as Name of old object. Possible it was no changed.</li>
<li><strong>Delete</strong> request passed id of object of corresponding class that has been deleted.</br>
But, if id is null or is absent in the repository the request will be rejected.</li>
</ul>
Only work localization of seeded animals objects. Other objects don't have localization.</br>
Data of fields of animals object that was seeded are available in Resourses files according to localizations.<br>
But no any data that was seeded of Addresses or Zoo are available in Resourses files.</br>
Each data in Entity Framework solution has to have additional fields in preferred language localization.</br>
</br>
<h3>Tests</h3>
Project has MStest of AnimalsService methods.</br>
AnimalsService passed all tests on GetAll, Get, Add, Update and Delete methods.</br>
Checked all possible data that can be transferred to Service by request.</br>
</br>
<img src="https://github.com/ArchRafail/AnimalsOnPages/blob/2f3f320f8a2895b1ee4d109f2e9e1aa4c44db6f4/AnimalsTestProject.JPG" alt="Animals test project result">
