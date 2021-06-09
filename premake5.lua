workspace "Kriptografija"
architecture "x86_64"
startproject "CeaserCypherC++"

configurations { "Debug", "Release" }
    
    flags
	{
		"MultiProcessorCompile"
    }
    
    outputdir = "%{cfg.buildcfg}-%{cfg.system}-%{cfg.architecture}"

    IncludeDir = {}
    IncludeDir["cryptopp"] = "Vendor/cryptopp"
    IncludeDir["FMT"] = "Vendor/fmt/include"

    group "Dependencies"
    include "Vendor/fmt"
    group ""

    project "CeaserCypherC++"
            location "CeaserCypherCPP"
            kind "ConsoleApp"
            language "C++"
            cppdialect "C++17"
            staticruntime "on"

            targetdir ("bin/" .. outputdir .. "/%{prj.name}")
            objdir("bin-int/" .. outputdir .. "/%{prj.name}")

            files
            {
                "%{prj.name}/src/*.h",
                "%{prj.name}/src/*.hpp",
                "%{prj.name}/src/*.cpp",
            }

            defines
            {
                "_CRT_SECURE_NO_WARNINGS",
            }

            includedirs
            {
                "%{prj.name}/src/*",
                "%{IncludeDir.fmt}"             
            }

            filter "configurations:Debug"
                    defines { "DEBUG" }
                    runtime "Debug"
                    symbols "On"
              
                 filter "configurations:Release"
                    defines { "NDEBUG" }
                    runtime "Release"
                    optimize "On"

    project "AESCpp"
            location "AESCpp"
            kind "ConsoleApp"
            language "C++"
            cppdialect "C++17"
            staticruntime "on"

            targetdir ("bin/" .. outputdir .. "/%{prj.name}")
            objdir("bin-int/" .. outputdir .. "/%{prj.name}")

            files
            {
                "%{prj.name}/src/*.h",
                "%{prj.name}/src/*.hpp",
                "%{prj.name}/src/*.cpp",
            }

            defines
            {
                "_CRT_SECURE_NO_WARNINGS",
            }

            includedirs
            {
                "%{prj.name}/src/*",
                "%{IncludeDir.fmt}",
                "%{IncludeDir.cryptopp}"             
            }

            filter "configurations:Debug"
                    defines { "DEBUG" }
                    runtime "Debug"
                    symbols "On"
                    libdirs
                    {
                        "%{IncludeDir.cryptopp}/x64/Output/Debug"
                    }
        
                    links
                    {
                        "cryptlib"
                    }
              
                 filter "configurations:Release"
                    defines { "NDEBUG" }
                    runtime "Release"
                    optimize "On"
                    libdirs
                    {
                        "%{IncludeDir.cryptopp}/x64/Output/Release"
                    }
        
                    links
                    {
                        "cryptlib"
                    }

    project "PWManager"
            location "PWManager"
            kind "WindowedApp"
            language "C#"
            staticruntime "on"
        
                    targetdir ("bin/" .. outputdir .. "/%{prj.name}")
                    objdir("bin-int/" .. outputdir .. "/%{prj.name}")
        
                    files
                    {
                        "%{prj.name}/src/**.cs",
                        "%{prj.name}/*.cs",
                        "%{prj.name}/*.resx",
                        
                    }

                    links { "System",
                    "System.Core",
                    "Microsoft.CSharp",
                    "System.Windows.Forms",
                    "System.Collections.Generic",
                    "System.Runtime.Serialization",
                    "System.ComponentModel.DataAnnotations"
                    ,"System.Drawing"
                    ,"System.Data"
                    ,"CsvHelper"
                    ,"Konscious.Security.Cryptography.Argon2" 
                    ,"Konscious.Security.Cryptography.Blake2"}

                    nuget{"CsvHelper:27.0.4"
                    ,"Konscious.Security.Cryptography.Argon2:1.2.1" 
                    ,"Konscious.Security.Cryptography.Blake2:1.0.9"}

    project "RSACpp"
            location "RSACpp"
            kind "ConsoleApp"
            language "C++"
            cppdialect "C++17"
            staticruntime "on"
                    
                targetdir ("bin/" .. outputdir .. "/%{prj.name}")
                objdir("bin-int/" .. outputdir .. "/%{prj.name}")
                    
                files
                {
                    "%{prj.name}/src/*.h",
                    "%{prj.name}/src/*.hpp",
                    "%{prj.name}/src/*.cpp",
                }
                
                defines
                {
                    "_CRT_SECURE_NO_WARNINGS",
                }
                
                includedirs
                {
                    "%{prj.name}/src/*",
                    "%{IncludeDir.FMT}"     
                }
                links
                {
                    "FMT",
                }
                
                filter "configurations:Debug"
                        defines { "DEBUG" }
                        runtime "Debug"
                        symbols "On"

                     filter "configurations:Release"
                        defines { "NDEBUG" }
                        runtime "Release"
                        optimize "on"

    project "FirstLevelRSASignature"
            location "FirstLevelRSASignature"
                kind "WindowedApp"
                language "C#"
                staticruntime "on"
            
                        targetdir ("bin/" .. outputdir .. "/%{prj.name}")
                        objdir("bin-int/" .. outputdir .. "/%{prj.name}")
            
                        files
                        {
                            "%{prj.name}/src/**.cs",
                            "%{prj.name}/*.cs",
                            "%{prj.name}/*.resx",
                            
                        }
    
                        links { "System",
                        "System.Core",
                        "Microsoft.CSharp",
                        "System.Windows.Forms",
                        "System.Collections.Generic",
                        "System.Runtime.Serialization",
                        "System.ComponentModel.DataAnnotations"
                        ,"System.Drawing"
                        ,"System.Data"
                        ,"CsvHelper"
                        ,"Konscious.Security.Cryptography.Argon2" 
                        ,"Konscious.Security.Cryptography.Blake2"}
    
                        nuget{"CsvHelper:27.0.4"
                        ,"Konscious.Security.Cryptography.Argon2:1.2.1" 
                        ,"Konscious.Security.Cryptography.Blake2:1.0.9"}

    project "SecondLevelRSASignature"
            location "SecondLevelRSASignature"
                            kind "WindowedApp"
                            language "C#"
                            staticruntime "on"
                        
                                    targetdir ("bin/" .. outputdir .. "/%{prj.name}")
                                    objdir("bin-int/" .. outputdir .. "/%{prj.name}")
                        
                                    files
                                    {
                                        "%{prj.name}/src/**.cs",
                                        "%{prj.name}/*.cs",
                                        "%{prj.name}/*.resx",
                                        
                                    }
                
                                    links { "System",
                                    "System.Core",
                                    "Microsoft.CSharp",
                                    "System.Windows.Forms",
                                    "System.Collections.Generic",
                                    "System.Runtime.Serialization",
                                    "System.ComponentModel.DataAnnotations"
                                    ,"System.Drawing"
                                    ,"System.Data"
                                    ,"CsvHelper"
                                    ,"Konscious.Security.Cryptography.Argon2" 
                                    ,"Konscious.Security.Cryptography.Blake2"}
                
                                    nuget{"CsvHelper:27.0.4"
                                    ,"Konscious.Security.Cryptography.Argon2:1.2.1" 
                                    ,"Konscious.Security.Cryptography.Blake2:1.0.9"}