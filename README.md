# Store branches management software

This software is used to manage multiple store branches in different areas

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

## Prerequisites

Windows10-intel core i3-input(output) hardware

```
Give examples
```
### Function

* Adding Store branches 
* Create delivery notes
* Search
* Create receipts
* Create monthly report
* Make changes in rules of branch management (max number of braches, items, unit)
* ...in development

## Status quo

## organizational status
![alt text](https://github.com/hvtanh07/pm-quan-ly-dai-ly/blob/master/httc.png)

## Business status

* see the [funtion](#function) section

## 

### Installing

* 1: Clone or download the project to your drive
* 2: Open Microsoft SQL Management Studio an copy your server's name 
* 3: Open and edit 'createDBQLDL.cmd' in \pm-quan-ly-dai-ly\Database
* 4: Replace 'TUAN-ANH' with your server's name 
* 5: save -> close -> run the cmd file
* 6: The database should be created in your server
* 7: Open QLDL.sln in \pm-quan-ly-dai-ly\visual with Microsoft Visual Studio

## Running the tests

The project included with a sql(createQLDL.sql) file located in \pm-quan-ly-dai-ly\Database. We've already included some Store branches, Items as well as Delivery notes for testing purpose.If you need to edit it do it before running the createDBQLDL.cmd

## Deployment

This software is in it's very early build and only using as a school report. If you want a further development please feel free to contact us. See the [Authors](#Authors) section for contact info

## Built With

* (https://visualstudio.microsoft.com/) - Microsoft Visual Studio 2017
* (https://www.microsoft.com/en-us/sql-server/sql-server-2017) - Microsoft SQL Sever 2017

## Contributing

Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

* 2.0:New UI built with WPF and minor bug fixed
* 1.0:Early build with all the funtion listed in [Function](#Function)

## Authors

* Hứa Văn Tuấn Anh - 17520232@gm.uit.edu.vn

* Phạm Quang Thịnh

* Nguyễn Việt Mỹ


## License

This project is licensed under the University of Information & Technology
![alt text](https://upload.wikimedia.org/wikipedia/commons/thumb/0/06/Logo_UIT_In.jpg/220px-Logo_UIT_In.jpg)

## Acknowledgments

* Hat tip to anyone whose code was used
* Inspiration
* etc
