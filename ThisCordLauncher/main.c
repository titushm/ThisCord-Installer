// clang .\main.c -o ThisCord.exe "-Wl,/SUBSYSTEM:WINDOWS"
#pragma comment(lib, "user32.lib")
#include <windows.h>
#include <stdio.h>

typedef int (__stdcall *Py_BytesMain)(int argc, char** argv);

ULONG_PTR EnableVisualStyles(VOID) { //https://stackoverflow.com/a/10444161/15755351
	TCHAR dir[MAX_PATH];
	ULONG_PTR ulpActivationCookie = FALSE;
	ACTCTX actCtx =
	{
		sizeof(actCtx),
		ACTCTX_FLAG_RESOURCE_NAME_VALID
			| ACTCTX_FLAG_SET_PROCESS_DEFAULT
			| ACTCTX_FLAG_ASSEMBLY_DIRECTORY_VALID,
		TEXT("shell32.dll"), 0, 0, dir, (LPCTSTR)124
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

int main(int argc, char** argv) {
	EnableVisualStyles();
	if (!FileExists("python3.dll")) {
		if (MessageBox(
			NULL,
			"the file `python3.dll` dosent exist.",
			"Error",
			MB_ICONERROR|MB_RETRYCANCEL|MB_DEFBUTTON2
		)==IDRETRY){return main(argc,argv);}
		return 1;
	}

	HINSTANCE python3dll = LoadLibrary("python3.dll");

	if (!python3dll) {
		if (MessageBox(
			NULL,
			"could not load the dynamic library.",
			"Error",
			MB_ICONERROR|MB_RETRYCANCEL|MB_DEFBUTTON2
		)==IDRETRY){return main(argc,argv);}
		return 2;
	}

	// resolve function address here
	Py_BytesMain py_BytesMain = (Py_BytesMain)GetProcAddress(python3dll, "Py_BytesMain");
	if (!py_BytesMain) {
		if (MessageBox(
			NULL,
			"could not locate the function.",
			"Error",
			MB_ICONERROR|MB_RETRYCANCEL|MB_DEFBUTTON2
		)==IDRETRY){return main(argc,argv);}
		return 3;
	}

	char** pyargv = malloc((argc+1)*sizeof pyargv[0]);

	pyargv[0] = argv[0];
	pyargv[1] = "../ThisCord-master/src/main.py";
	for (size_t i = 1; i < argc; i++) { pyargv[i+1] = argv[i]; }

	return py_BytesMain(argc+1, pyargv);
	// free pyargv will be done by the OS (hopefully)
}

int __stdcall WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, char* _, int nShowCmd)
{ return main(__argc, __argv); }
