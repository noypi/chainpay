call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\Tools\VsDevCmd.bat"

cd ..
msbuild ChainPay.sln /target:ChainPay:Rebuild /property:Configuration=Release /property:Platform="Any CPU"
msbuild ChainPay.sln /target:ChainPay_Net45:Rebuild /property:Configuration=Release /property:Platform=x64
msbuild ChainPay.sln /target:ChainPay_Net45:Rebuild /property:Configuration=Release /property:Platform=x86

pause