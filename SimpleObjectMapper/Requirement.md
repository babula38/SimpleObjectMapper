# Markdown File

-	(Done)Should map the properties
	A.ID=B.ID
	A.Name=B.Name

-	(done)	Mapper should work with Arry & list element.
	///code c#
	A[] should be mapped to B[]

-	(DONE)Mapper should work with Arry & list element.
	///code c#
	List<A> should be mapped to List<B>

		--------------
	----|Child element |----
		--------------
-	[DONE]Mapper should work with complex chield elment.
	Class A{
		public B B{get;set;}
	}
	Class B{}

	Note:- used both custom child mapper and manual property assign ment

-	Work with child list & array element.
	Class A{
		public List<B> BList{get;set;}
	}
	Class B{}

-	