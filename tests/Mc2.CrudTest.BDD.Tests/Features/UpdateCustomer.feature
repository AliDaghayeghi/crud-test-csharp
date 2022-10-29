Feature: UpdateCustomer
	Different scenarios for updating customers

    Scenario: Update customer with valid data
		Given customer information for update are (<Id>,<FirstName>,<LastName>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		When the update validation result is succeeded
		Then the update operation result should be succeeded
	
	Examples:
		| Id | FirstName | LastName        | DateOfBirth | PhoneNumber   | Email                | BankAccountNumber |
		| 1  | Ali       | Daghayeghi      | 19991230    | +989123214343 | ali@gmail.com        | 4999999999999103  |
		| 1  | Reza      | MohammadiGilani | 19950402    | +989168765454 | Reza@yahoo.com       | 5610591081018250  |
		| 1  | Mohammad  | Rezae           | 19830405    | +31616800987  | Mohammad@outlook.com | 5555555555554444  |
		| 1  | Hosein    | Imani           | 20010701    | +60126496554  | Hosein@gmail.com     | 4012888888881881  |
		| 1  | Mahsa     | Amini           | 19920203    | +989123455432 | Mahsa@amini.com      | 4111111111111111  |
 
	Scenario: Update customer with repeated email
		Given customer information for update are (<Id>,<FirstName>,<LastName>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		When the update validation result is succeeded
		Then the update operation result should be failed with error code 12002
		
	Examples:
	 	| Id | FirstName    | LastName   | DateOfBirth | PhoneNumber   | Email             | BankAccountNumber |
	    | 1  | Ali          | Daghayeghi | 19951220    | +989123214567 | ali@test.com      | 4999999999999103  |
	    | 1  | Hasan        | Abbasi     | 19991210    | +31616800987  | Ali@test.com      | 5555555555554444  |
	    | 1  | Hosein       | Hasani     | 19971223    | +989342456886 | ali@TEST.com      | 4999999999999103  |
	    | 2  | MohammadAli  | Imani      | 19971223    | +982344234541 | siNA@TEST.com     | 4111111111111111  |
	    | 1  | MohammadReza | Mohammadi  | 19971223    | +31616800921  | MOHAMMAD@TEST.com | 5610591081018250  |
     
	Scenario: Update customer with invalid email
		Given customer information for update are (<Id>,<FirstName>,<LastName>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then the update validation result should be failed with error code 12008
		
	Examples:
		| Id | FirstName   | LastName   | DateOfBirth | PhoneNumber   | Email               | BankAccountNumber |
		| 1  | Ali         | Daghayeghi | 19951220    | +989123214567 | alest.com           | 4999999999999103  |
		| 1  | MohammadAli | Imani      | 19971223    | +982344234541 | siESTm              | 4111111111111111  |
		| 1  | Hosein      | Imani      | 20010701    | +60126496554  | Hoseinail.net       | 4012888888881881  |
		| 1  | Hasan       | Abbasi     | 19991210    | +989123886743 | Al#$%$^gmail.com    | 5555555555554444  |
		| 1  | MohammadAli | Imani      | 19971223    | +982344234541 | sidfbSoa.com.com@@m | 4111111111111111  |
  
	Scenario: Update customer with valid phone number
		Given customer information for update are (<Id>,<FirstName>,<LastName>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		When the update validation result is succeeded
		Then the update operation result should be succeeded
		
	Examples:
		| Id | FirstName   | LastName   | DateOfBirth | PhoneNumber   | Email         | BankAccountNumber |
		| 1  | Ali         | Daghayeghi | 19951220    | +989220921234 | ali1@test.com | 4999999999999103  |
		| 1  | MohammadAli | Imani      | 19971223    | +31616800123  | ali2@test.com | 4111111111111111  |
		| 1  | Hosein      | Imani      | 20010701    | +60126496123  | ali3@test.com | 4012888888881881  |
		| 1  | Hasan       | Abbasi     | 19991210    | +989161234545 | ali4@test.com | 5555555555554444  |
		| 1  | MohammadAli | Imani      | 19971223    | +989373456767 | ali5@test.com | 4111111111111111  |
  
	Scenario: Update customer with invalid phone number
		Given customer information for update are (<Id>,<FirstName>,<LastName>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then the update validation result should be failed with error code 12006
		
	Examples:
		| Id | FirstName   | LastName   | DateOfBirth | PhoneNumber         | Email         | BankAccountNumber |
		| 1  | Ali         | Daghayeghi | 19951220    | 3435567             | ali1@test.com | 4999999999999103  |
		| 1  | MohammadAli | Imani      | 19971223    | +316168345009873345 | ali2@test.com | 4111111111111111  |
		| 1  | Hosein      | Imani      | 20010701    | +601264545          | ali3@test.com | 4012888888881881  |
		| 1  | Hasan       | Abbasi     | 19991210    | +989712386743       | ali4@test.com | 5555555555554444  |
		| 1  | MohammadAli | Imani      | 19971223    | +9465241            | ali5@test.com | 4111111111111111  |
  
	Scenario: Update customer with invalid bank account number
		Given customer information for update are (<Id>,<FirstName>,<LastName>,<DateOfBirth>,<PhoneNumber>,<Email>,<BankAccountNumber>)
		Then the update validation result should be failed with error code 12007
		
	Examples:
		| Id | FirstName   | LastName   | DateOfBirth | PhoneNumber   | Email         | BankAccountNumber         |
		| 1  | Ali         | Daghayeghi | 19951220    | +989220921234 | ali1@test.com | 499999435665879999103     |
		| 1  | MohammadAli | Imani      | 19971223    | +60126496123  | ali2@test.com | 23456511113221111         |
		| 1  | Hosein      | Imani      | 20010701    | +989161234545 | ali3@test.com | 4012888888881845678998781 |
		| 1  | Hasan       | Abbasi     | 19991210    | +989373456767 | ali4@test.com | 5555565555554444          |
		| 1  | MohammadAli | Imani      | 19971223    | +989220923434 | ali5@test.com | 678907611111331111        |