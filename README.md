# Spy4Silk
The application is for people who use Silk4Net (https://www.microfocus.com/en-us/products/silk-test/overview) for automated testing. 
The application provide In-depth analysis of application controls and helps in finding relation netween controls.
* UseCase : The application you are going to test, uses 3rd party control inside the application, you probably needs detailed analysis to find 
relation between controls.

## Prerequisite
* Need Visual Studio 2015 or above.
* Need valid licene for Silk. (Note I am using Silk 18.5)
* I used DevExpress to develop the app. I hope you might not need the licence.(Fingers Crossed)

## How to setup.
* Load the project in visual studio.
* Edit the the Silk Configuration in Visual Studio, to add the application you need to spy the controls on.

## How to use.
* Use the silk locator spy from silk, to get the xpath of the control you want to look in detail. 
    Example of XPath: //WPFControl[@automationId='DisassemblyTreeListControl'] 
* Run the Spy4Silk application.
* Select the application to spy on from the popup window.
![Alt text](/Example/AppSelect.jpg?raw=true "App selection")
* Paste the XPath in 'Control Xpath' textbox and click proces. 
* It will load all method and property details.

## Features
* Property Highlight : If you process the same Xpath again in the same Tab. 
    * It will show property with changed value with a Yellow color
    * It will show new property with Green color.

* Method Invoke : You can invoke a method by selecting a method
    * In case of no parameter, just click Invoke
    * In case of basic parameters (like int, string, double, char), add value in 'Parameters box and press invoke.
        * Example, I need to invoke a method of declartion: ___GetRowElementByRowHandle(int position)___ , 
        I click the method in the list and set the value, lets say 3, in the text box and press Invoke.
        * The result of this execution will be shown, specifying the result type and value.

* XPath Tools: It will do highlight and click operation on the current xpath object.

* Property/Method Tools: It does operation on control objects in property list 
( In future to add support to do operation on result of methods as well.)
    * In case, value of a property is a control type (In Silk4Net term : TestObject), 
    you can click the property and do Click and Hightlight operation.
    * In case you want to find the details of the control inside the property.
      * Select the property and press ___Get Details___.
      * It will open a new tab and loads all the property and method details of it.
      * You can also see the xpath also will get udpated accordingly, so that you get a track of how to reach the point.
      Example, when i pressed ___Get Details___ for view a new tab is added with xpath 
      as __//WPFControl[@automationId='DisassemblyTreeListControl'].View__
* Xpath supports method, property, normal xpath together.
  * Example: __//WPFControl[@automationId='DisassemblyTreeListControl'].View.GetRowElementByRowHandle(2)__ , lets look inside.
      * First it will get WPFControl having automationId = 'DisassemblyTreeListControl'.
      * View property of the above WPFControl is fetched.
      * Then the method __GetRowElementByRowHandle with pararmeter 2__ is invoked on control from view.
      * The details of the control from the method is populated on the table.
       ![Alt text](/Example/NormalUseCase.jpg?raw=true "Xpath Example")
  
 ## Note
* We used this to test an application on WPF and its used multiple 3rd party controls such as DevExpress, SciChart and few more.
  This helped us a lot.  
* I wish SILK will incorparate this to their tools.
* Hope this helps.
 
