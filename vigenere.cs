void Main()
{
	Console.WriteLine(Encode("reddit", "todayismybirthday"));
	Console.WriteLine(Decode("reddit", "KSGDGBJQBEQKKLGDG"));
	
	
	//"ZEJFOKHTMSRMELCPODWHCGAW"
}

// Define other methods and classes here

string Encode(string cipher, string text) {
	int asciiIndex = 65;
	cipher = cipher.ToUpper();
	text = text.ToUpper();
	
	var cipherArray = cipher.ToCharArray().Select(x => x-asciiIndex).ToArray();
	var textArray = text.ToCharArray().Select(x => x-asciiIndex).ToArray();
	var outputArray = new int[textArray.Count()];
	
	int cipherIndex = 0;
	for(int i = 0; i < outputArray.Count(); i++) {
		outputArray[i] = mod((textArray[i] + cipherArray[cipherIndex]), 26);
		cipherIndex = (cipherIndex + 1) % cipher.Length;
	}
	char[] output = outputArray.Select(x => Convert.ToChar(x+asciiIndex)).ToArray();
	return string.Join("", output);
}

string Decode(string cipher, string cipherText) {
	int asciiIndex = 65;
	cipher = cipher.ToUpper();
	cipherText = cipherText.ToUpper();
	
	var cipherArray = cipher.ToCharArray().Select(x => x-asciiIndex).ToArray();
	var cipherTextArray = cipherText.ToCharArray().Select(x => x-asciiIndex).ToArray();
	var outputArray = new int[cipherTextArray.Count()];
	
	int cipherIndex = 0;
	for(int i = 0; i < outputArray.Count(); i++) {
		outputArray[i] = mod((cipherTextArray[i] - cipherArray[cipherIndex]),26);
		cipherIndex = (cipherIndex + 1) % cipher.Length;
	}
	char[] output = outputArray.Select(x => Convert.ToChar(x+asciiIndex)).ToArray();
	return string.Join("", output);
}

int mod(int x, int m) {
    int r = x%m;
    return r<0 ? r+m : r;
}
