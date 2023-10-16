All data is saved in the Data folder and on the DataManager. If you need to delete the save, set the value to true on the DataManager GameObject, which is located on the scene.
To work with the user interface, the MVVM pattern is used, built on Bindings, data is taken from ScriptableObjects, saving is serialized and deserialized from a json file.
