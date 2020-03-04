# Markdown File

-	(Done)Should map the properties
	A.ID=B.ID
	A.Name=B.Name

-	Mapper should work with Arry & list element.
	///code c#
	List<A> should be mapped to List<B>

-	Mapper should work with complex chield elment.
	Class A{
		public B B{get;set;}
	}
	Class B{}

-	Work with child list & array element.
	Class A{
		public List<B> BList{get;set;}
	}
	Class B{}

-	