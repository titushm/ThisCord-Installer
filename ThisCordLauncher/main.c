// clang .\main.c -o ThisCord.exe -Wall -Wextra "-Wl,/SUBSYSTEM:WINDOWS"
// rh -open .\ThisCord.exe -save .\ThisCord.exe -action addskip -res ..\ThiscordIcon.ico -mask "ICONGROUP,MAINICON,"
#pragma comment(lib, "user32.lib")
#include <windows.h>
#include <stdio.h>

typedef int (__stdcall *Py_BytesMain)(int argc, char** argv);
typedef void (__stdcall *Py_Initialize)(void);

ULONG_PTR EnableVisualStyles(VOID) { //https://stackoverflow.com/a/10444161/15755351
	TCHAR dir[MAX_PATH];
	ULONG_PTR ulpActivationCookie = FALSE;
	ACTCTX actCtx =
	{
		sizeof(actCtx),
		ACTCTX_FLAG_RESOURCE_NAME_VALID
			| ACTCTX_FLAG_SET_PROCESS_DEFAULT
			| ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID,
		TEXT("shell32.dll"), 0, 0, dir, (LPCTSTR)124,
		0,0,
	};
	UINT cch = GetSystemDirectory(dir, sizeof(dir) / sizeof(*dir));
	if (cch >= sizeof(dir) / sizeof(*dir)) { return FALSE; /*shouldn't happen*/ }
	dir[cch] = TEXT('\0');
	ActivateActCtx(CreateActCtx(&actCtx), &ulpActivationCookie);
	return ulpActivationCookie;
}
BOOL FileExists(LPCTSTR szPath) {
	DWORD dwAttrib = GetFileAttributes(szPath);
	return (dwAttrib != INVALID_FILE_ATTRIBUTES && !(dwAttrib & FILE_ATTRIBUTE_DIRECTORY));
}

// this could be python3.dll however due to a bug in python the forwarded calls in
// python3.dll first check the path for python 310.dll which means if you happen to
// have python 3.10 installed in your path you get that dll not the one we just
// installed meaning none of the packages are installed meaning it all crashes. (this
// is fixed in newer versions of python however calling directly not using the
// forwarded python3.dll calls should always be more stable anyway (not to mention
// python310.dll actualy has more functions that are not exposed in python3.dll
// (although this shouldnt matter as we dont use any of them)))
#define PYTHON3_DLL_PATH "\\py\\python310.dll"
#define MAIN_PATH "\\ThisCord-master\\src\\main.py"
#define EXTRA_ARGS 1

static int maxPathError(void){
	// this is not retryable as the results will require the executable to be moved which will mean they will need to close the app
	MessageBox(
		NULL,
		"Error the path to `"PYTHON3_DLL_PATH"` is beyond the maximum path size please install it somewhere else and try again.",
		"Error",
		MB_ICONERROR|MB_OK
	);
	return 1;
}

int main(int argc, char** argv) {
	EnableVisualStyles();

	char* exePath = malloc(sizeof exePath[0] * MAX_PATH);

	if (GetModuleFileName(NULL,exePath,MAX_PATH) == MAX_PATH) {return maxPathError();}

	char* lastSlash = strrchr(exePath, '\\');
	if (lastSlash == NULL) {
		MessageBox(
			NULL,
			"Error the path to `"PYTHON3_DLL_PATH"` is malformed.",
			"Error",
			MB_ICONERROR|MB_OK
		);
		return 1;
	}
	*lastSlash = 0; // change the last slash for the end of the string

	if (strlen(exePath)>MAX_PATH - sizeof(PYTHON3_DLL_PATH)) {return maxPathError();}

	size_t python3dllPathSize = sizeof exePath[0] * (strlen(exePath) + sizeof(PYTHON3_DLL_PATH));
	char* python3dllPath = malloc(python3dllPathSize);

	strcpy_s(python3dllPath, python3dllPathSize, exePath);
	strcat_s(python3dllPath, python3dllPathSize, PYTHON3_DLL_PATH);

	if (!FileExists(python3dllPath)) {
		if (MessageBox(
			NULL,
			"the file `"PYTHON3_DLL_PATH"` dosent exist.",
			"Error",
			MB_ICONERROR|MB_RETRYCANCEL|MB_DEFBUTTON2
		)==IDRETRY){return main(argc,argv);}
		return 1;
	}

	HINSTANCE python3dll = LoadLibrary(python3dllPath);
	free(python3dllPath);

	if (!python3dll) {
		if (MessageBox(
			NULL,
			"could not load the dynamic library.",
			"Error",
			MB_ICONERROR|MB_RETRYCANCEL|MB_DEFBUTTON2
		)==IDRETRY){return main(argc,argv);}
		return 1;
	}

	Py_BytesMain py_BytesMain = (Py_BytesMain)GetProcAddress(python3dll, "Py_BytesMain");
	Py_Initialize py_Initialize = (Py_Initialize)GetProcAddress(python3dll, "Py_Initialize");
	if (!py_BytesMain || !py_Initialize) {
		if (MessageBox(
			NULL,
			"could not locate the functions (you might have a corrupt installation).",
			"Error",
			MB_ICONERROR|MB_RETRYCANCEL|MB_DEFBUTTON2
		)==IDRETRY){return main(argc,argv);}
		return 1;
	}

	char** pyargv = malloc((argc+EXTRA_ARGS)*sizeof pyargv[0]);

	if (strlen(exePath)>MAX_PATH - sizeof(MAIN_PATH)) {
		MessageBox(
			NULL,
			"Error the path to `"MAIN_PATH"` is beyond the maximum path size please install it somewhere else and try again.",
			"Error",
			MB_ICONERROR|MB_OK
		);
		return 1;
	}

	size_t mainPathSize = sizeof exePath[0] * (strlen(exePath) + sizeof(MAIN_PATH));
	char* mainPath = malloc(mainPathSize);

	strcpy_s(mainPath, mainPathSize, exePath);
	strcat_s(mainPath, mainPathSize, MAIN_PATH);

	py_Initialize();

	pyargv[0] = argv[0];
	pyargv[1] = mainPath;
	for (int i = 1; i < argc; i++) { pyargv[i+EXTRA_ARGS] = argv[i]; }
	return py_BytesMain(argc+1, pyargv);
	// free's will be done by the OS (hopefully)
}

int __stdcall WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, char* pCmdLine, int nShowCmd)
{
	(void)hInstance;
	(void)hPrevInstance;
	(void)pCmdLine;
	(void)nShowCmd;
	return main(__argc, __argv);
}
