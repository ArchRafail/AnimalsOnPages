# AnimalsOnPages
ASP.Net project on RazorPages with CRUD service. RAM Repository. 2 language localization. MStest of Service.
</br>
</br>
<h3>Pages</h3>
Web-site about animals with 2 main Pages on MenuTab: Animals (Index) and Add animal.</br>
Each animal that shows on <strong>Index-page</strong> wrapped in card and has 2 buttons: Find out more and Delete.</br>
Button "Find out more" redirect us to additional page Animal Details.</br>
With "Delete" button we can delete animal from repository.</br>
Additional page <strong>Animal Details</strong> shows us only one card with same animal that button was pressed.</br>
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
Each page has 2 language localization: English and Ukrainian.</br>
</br>
<h3>Service</h3>
AnimalsService provides us CRUD methods: GetAll, Get, Add, Update, Delete.</br>
Service works with RAM repository with list of 3 classes of Animal: Amphibia, Mammal and Reptile.</br>
Repository list set on the start with 5 animals: 2 of Mammal, 2 of Reptile and 1 of Amphibia.</br>
Requests in AnimalsService:</br>
<ul>
<li><strong>GetAll</strong> request returns list of animals. Nothing special.</li>
<li><strong>Get</strong> request returns animal with defined id, but, if id is null or is absent in the repository method returns null.</li>
<li>In <strong>Add</strong> request, service validate everything before request will be passed to repository.</br>
Id in this request will be placed automatically according to the size of the animals list.</br>
String classOfAnimal are required in this request, so if it null or not one of 3 available, the request will be rejected.</br>
Fields Name and Sound are required, so if they are null the request will be rejected.</br>
If field Name is already in the list of animals, request will be rejected.</br>
If fields Sex and Rank service receive as null, they will be defined "Man" and "Carnivorous" respectively.</br>
Field CoverColor will be filled automatically with "No Specified", if we leaved it blank.</br>
Add method of Service accepts AnimalDto object that has fields Id, Name, Sex, Rank, Sound, CoverColor.</br>
Then Service create Animal according to classOfAnimal, the string that also accepts Service.</br>
Other class fields will be filled to respectively of class of animal.</li>
<li>In <strong>Update</strong> request, service validate everything before request will be passed to repository.</br>
Id in this request will be checked if it already in the list of animal. If no - the request will be rejected.</br>
Other fields are validating according to Add request.</br>
Field Name, by exception of Add request, can be the same as Name of old animal. Possible it was no changed.</li>
<li><strong>Delete</strong> request passed id of animal that has been deleted.</br>
But, if id is null or is absent in the repository the request will be rejected.</li>
</ul>
All fields from Each animal at list of animals have 2 language localization: English and Ukrainian.</br>
Localization doesn't work in 2 cases:</br>
<ol>
<li>When new animal was added to the repository.</br>
Only english localization of fields Name, Sound and CoverColor will be shown on Index-page and Animal Details page.</br>
It is because no any additional data of these field are available in Resourses files according to localizations.<br>
Possible to avoid this - to work with DataBase and Entity Framework solution.</br>
Localization of animals fields should be stored in DataBase.</li>
<li>When animal was updated.</br>
Localization of old animal fields Name, Sound and CoverColor will be shown on Index-page and Animal Details page.</br>
It is because Razor Page reads resourses when shows animal's Name, Sound and CoverColor fields.<br>
But updated field are no longer available in Resourses files according to localizations.</br>
Possible to avoid this - to work with DataBase and Entity Framework solution.</br>
Localization of animals fields should be stored in DataBase.</li>
</ol>
</br>
<h3>Tests</h3>
Project has MStest of AnimalsService methods.</br>
AnimalsService passed all tests on GetAll, Get, Add, Update and Delete methods.</br>
Checked all possible data that can be transferred to Service by request.</br>
</br>
<img src="https://github.com/ArchRafail/AnimalsOnPages/blob/2f3f320f8a2895b1ee4d109f2e9e1aa4c44db6f4/AnimalsTestProject.JPG" alt="Animals test project result">
