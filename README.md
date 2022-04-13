# Game Framework quick
 Mandatory Assignment in Advanced Software Construction


The framework is in the GameOfSolidAndDesignPatterns folder
The GUI is in the BoardGameGui
The Documentation is in the Doxygen folder.
You will need to build the project to thereafter copy paste the ConfigSettings.xml file to the Game-Framework-quick\BoardGameGui\bin\Debug\net5.0 in BoardGameGui

This is an anssignment to proove the factory pattern, state pattern and the singleton pattern.
The solid principles is in the way I've done the Items and Participants and kept the behavior and the startup closed for modification and open for extension,
and Liskov Substitution Principle, in which the weaponBase class inheret from the interface IWeapon which makes the children Iron Mace or Wooden sword.
The use of interfaces, Interface Segregation Principle, WeaponBase and ArmorBase which inherent both from Item and there own interfaces.
Single-Responsibility Principle, in which the responsability is devided.
