#!/usr/bin/ruby
#
#Copyright (c) 2012, Yahoo! Inc.  All rights reserved.
#Copyrights licensed under the New BSD License. See the accompanying LICENSE
#file for terms.
#
require "stringio"
require File.join(File.dirname(__FILE__), "uuid")
  
PRODUCT_NAME = "Yahoo! 奇摩輸入法"

def replace_vcproj_version(filename, version)
  version_parts = version.split(/\./)
  
  file = File.open(filename, "r")
  output = StringIO.new
  
  while line = file.gets
    output.puts line
    if line =~ /<Configuration/
      while line = file.gets
        output.puts line
        if line =~ /<Tool/
          line = file.gets
          output.puts line
          if line =~ /Name=/ && (line =~ /VCCLCompilerTool/ || line =~ /VCResourceCompilerTool/)
            while line = file.gets
              if line =~ /PreprocessorDefinitions/
                # puts "before = #{line}"
                line.gsub!(/BASEIME_INSTALLER_VERSION=\\&quot;.+?\\&quot;/, "BASEIME_INSTALLER_VERSION=\\\\&quot;#{version}\\\\&quot;")
                line.gsub!(/BASEIME_RESOURCE_VERSION=\\&quot;.+?\\&quot;/, "BASEIME_RESOURCE_VERSION=\\\\&quot;#{version}\\\\&quot;")
                line.gsub!(/BASEIME_RESOURCE_VERSION_MAJOR=\d+/, "BASEIME_RESOURCE_VERSION_MAJOR=#{version_parts[0]}")
                line.gsub!(/BASEIME_RESOURCE_VERSION_MINOR=\d+/, "BASEIME_RESOURCE_VERSION_MINOR=#{version_parts[1]}")
                line.gsub!(/BASEIME_RESOURCE_VERSION_TINY=\d+/, "BASEIME_RESOURCE_VERSION_TINY=#{version_parts[2]}")
                # puts "after = #{line}"
                output.puts line
              elsif line =~ /\/>/
                output.puts line
                break
              else
                output.puts line
              end
            end            
          elsif line =~ /Name=/ && line =~ /VCLinkerTool/                        
            while line = file.gets
              if line =~ /Version/
                # puts "before = #{line}"
                line.gsub!(/Version=.+/, "Version=\"#{version}\"")
                # puts "after = #{line}"
                output.puts line
              elsif line =~ /\/>/
                output.puts line
                break
              else
                output.puts line
              end
            end                        
          else
          end
        end
      end
    end
  end  
  
  file.close
  
  file = File.open(filename, "w")
  file.print output.string
  file.close
end

def replace_assembly_info(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  
  while line = file.gets
    
    if line =~ /AssemblyVersion/ && line !~ /;/
      line = "[assembly: AssemblyVersion(\"#{version}.0\")]"
    elsif line =~ /AssemblyFileVersion/ && line !~ /;/
      line = "[assembly: AssemblyFileVersion(\"#{version}.0\")]"
    elsif line =~ /AssemblyVersionAttribute/
      line = "[assembly:AssemblyVersionAttribute(\"#{version}.0\")];"
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close
end

def replace_info_plist(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  
  while line = file.gets
    
    if line =~ /CFBundleVersion/
      output.puts line
      file.gets
      line = "    <string>#{version}</string>"
    elsif line =~ /MPVersion/
      output.puts line
      file.gets
      line = "    <string>#{version}</string>"      
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close
end

def replace_infoplist_strings(filename, version)
  version_parts = version.split(/\./)  
  file = File.open(filename, "r")
  output = StringIO.new  
  while line = file.gets
    
    if line =~ /\(r\d+\)/
      line.gsub!(/\(r\d+\)/, "(r#{version_parts[2]})")
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close
end

def replace_wxs(filename, version)
  version_parts = version.split(/\./)
  
  product_id = UUID.create_random.to_s.upcase
  package_id = UUID.create_random.to_s.upcase
  
  file = File.open(filename, "r")
  output = StringIO.new

  while line = file.gets
    
    if line =~ /<Product/
      line.gsub!(/Id=".+?"/, "Id=\"#{product_id}\"")
      
      if filename =~ /64\.wxs/
        line.gsub!(/Name=".+?"/, "Name=\"#{PRODUCT_NAME} #{version_parts[0]}.#{version_parts[1]} 正式版 (build #{version_parts[2]} x64)\"")        
      else
        line.gsub!(/Name=".+?"/, "Name=\"#{PRODUCT_NAME} #{version_parts[0]}.#{version_parts[1]} 正式版 (build #{version_parts[2]})\"")
      end
      line.gsub!(/Version=".+?"/, "Version=\"#{version}\"")
    elsif line =~ /<Package/
      line.gsub!(/Id=".+?"/, "Id=\"#{package_id}\"")
    # elsif line =~ /DefaultVersion/
    #   line.gsub!(/DefaultVersion=".+?"/, "DefaultVersion=\"#{version}\"")
    # elsif line =~ /removeuninstallkey/
    #   line.gsub!(/\*\d+\*/, "*#{version_parts[2]}*")
    elsif line =~ /KeyKeyVersion/ && line =~ /Registry/
      line.gsub!(/Value=".+?"/, "Value=\"#{version}\"")
    elsif line =~ /UpgradeVersion/
      line.gsub!(/\d+\.\d+\.\d+/, version)
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close  
end


def replace_extra_module_wxs(filename, version)
  version_parts = version.split(/\./)
  
  product_id = UUID.create_random.to_s.upcase
  package_id = UUID.create_random.to_s.upcase
  
  file = File.open(filename, "r")
  output = StringIO.new

  while line = file.gets
    
    if line =~ /<Product/
      line.gsub!(/Id=".+?"/, "Id=\"#{product_id}\"")
      line.gsub!(/Name=".+?"/, "Name=\"Yahoo! 奇摩輸入法外掛安裝包 #{version_parts[0]}.#{version_parts[1]} 正式版 (build #{version_parts[2]})\"")        
      line.gsub!(/Version=".+?"/, "Version=\"#{version}\"")
    elsif line =~ /<Package/
      line.gsub!(/Id=".+?"/, "Id=\"#{package_id}\"")
    elsif line =~ /UpgradeVersion/
      line.gsub!(/\d+\.\d+\.\d+/, version)
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close  
end


def replace_pkg_doc_xml(filename, version)
  version_parts = version.split(/\./)    
  content = IO.read(filename)
  content.gsub!(/<version>.+?<\/version>/, "<version>#{version_parts[2]}</version>")
  file = File.open(filename, "w")
  file.print content
  file.close  
end

def replace_panel_about_cs(filename, version)
  version_parts = version.split(/\./)    
  content = IO.read(filename)
  content.gsub!(/Yahoo.+?\(build \d+\)/, "Yahoo! KeyKey #{version_parts[0]}.#{version_parts[1]} (build #{version_parts[2]})")
  file = File.open(filename, "w")
  file.print content
  file.close
end

def replace_makefile(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  
  while line = file.gets    
    if line =~ /version \d+\.\d+\.\d+/
      line.gsub!(/version \d+\.\d+\.\d+/, "version #{version}")
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close
end

def combined_version(version)
  version_parts = version.split(/\./)    
  return "#{version_parts[0]}#{version_parts[1]}#{version_parts[2]}"
end

def replace_winbeacon_program_cs(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  

  version_parts = version.split(/\./)    

  
  while line = file.gets    
    if line =~ /string VersionForInstaller/
      line = "                string VersionForInstaller = \"#{version_parts[2]}\";"
    elsif line =~ /static string VersionForSearch/
      line = "        static string VersionForSearch = \"#{version_parts[2]}\";"
    elsif line =~ /define VERSION_FOR_SEARCH/
      line = "#define VERSION_FOR_SEARCH \"#{version_parts[2]}\""
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close
end

def replace_tracker_maker(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  

  version_parts = version.split(/\./)    

  while line = file.gets    
    if line =~ /m_takaoBuildNumber = /
      line = "            m_takaoBuildNumber = \"#{version_parts[2]}\";"
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close
end

def replace_flight(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  
  
  version_parts = version.split(/\./)    
  
  while line = file.gets    
    if line =~ /^VERSION_FOR_INSTALLER/
      line = "VERSION_FOR_INSTALLER=\"#{version_parts[2]}\";"
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close
end

def replace_sed(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  
  
  version_parts = version.split(/\./)    
  
  while line = file.gets    
    if line =~ /^TargetName=/
      line.gsub!(/-\d+.\d+.\d+/, "-#{version}")
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close  
end

def replace_makedist_bat(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  
  
  version_parts = version.split(/\./)    
  
  while line = file.gets    
    if line =~ /VERSION=/
      line.gsub!(/=.+/, "=#{version}")
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close  
end

def replace_make_py(filename, version)
  file = File.open(filename, "r")
  output = StringIO.new  
  
  version_parts = version.split(/\./)    
  
  while line = file.gets    
    if line =~ /version\s*=/
      line.gsub!(/=.+/, "= \"#{version}\"")
    end
    
    output.puts line
  end
  file.close  
  file = File.open(filename, "w")
  file.print output.string
  file.close  
end

def set_version(filename, version)
  if filename =~ /\.vcproj$/    
    replace_vcproj_version(filename, version)
  elsif filename =~ /AssemblyInfo.cs/
    replace_assembly_info(filename, version)
  elsif filename =~ /AssemblyInfo.cpp/
    replace_assembly_info(filename, version)
  elsif (filename =~ /AboutPanel.cs/ || filename =~ /PanelAbout.cs/)
    replace_panel_about_cs(filename, version)
  elsif filename =~ /Info.plist/
    replace_info_plist(filename, version)
  elsif filename =~ /-Windows.plist/
    replace_info_plist(filename, version)
  elsif filename =~ /ExtraModules\.wxs$/
    replace_extra_module_wxs(filename, version)    
  elsif filename =~ /Installer.+\.wxs$/
    replace_wxs(filename, version)
  elsif filename =~ /\InfoPlist.strings$/
    replace_infoplist_strings(filename, version)
  elsif filename =~ /01yahoo.xml/
    replace_pkg_doc_xml(filename, version)
  elsif filename =~ /Makefile/
    replace_makefile(filename, version)
  elsif filename =~ /WinBeacon\/Program.cs/
    replace_winbeacon_program_cs(filename, version)
  elsif filename =~ /Loaders\/Windows-IMM\/BaseIMEUI\/Config.cs/
    replace_winbeacon_program_cs(filename, version)
  elsif filename =~ /flight$/
    replace_flight(filename, version)
  elsif filename =~ /OVAFSearch.cpp/
    replace_winbeacon_program_cs(filename, version)    
  elsif filename =~ /TrackerMaker.h/
    replace_tracker_maker(filename, version)
  elsif filename =~ /\.sed$/
    replace_sed(filename, version)
  elsif filename =~ /makedist.bat/
    replace_makedist_bat(filename, version)
  elsif filename =~ /makedmg.py/
    replace_make_py(filename, version)
  end
end

files = %W{
  Loaders/Windows-IMM/BaseIME/BaseIME.vcproj
  Loaders/Windows-IMM/BaseIMEServer/BaseIMEServer.vcproj
  Loaders/Windows-IMM/BaseIMEServer/AssemblyInfo.cpp
  Loaders/Windows-IMM/BaseIMETool/BaseIMETool.vcproj
  Loaders/Windows-IMM/BaseIMEUI/Properties/AssemblyInfo.cs
  Loaders/Windows-IMM/QuickSetup/Properties/AssemblyInfo.cs
  Loaders/Windows-IMM/ServiceUI/AssemblyInfo.cpp
  Loaders/Windows-IMM/ServiceUI/ServiceUI.vcproj
  Loaders/Windows-IMM/PreferencesMain/AssemblyInfo.cpp
  Loaders/Windows-IMM/PreferencesMain/PreferencesMain.vcproj
  PreferenceApplications/Windows/Properties/AssemblyInfo.cs
  Loaders/Windows-IMM/BaseIMEUI/BIAboutPanel.cs
  Loaders/OSX-IMK/Takao-Info.plist
  Loaders/OSX-TSM/TakaoServer-Info.plist
  Loaders/OSX-TSM/TakaoComponent-Info.plist
  PreferenceApplications/OSX/Info.plist
  Distributions/Takao/Installer-Windows/Installer.wxs
  Distributions/Takao/Installer-Windows/Installer64.wxs
  Distributions/Takao/Installer-Windows/ExtraModules.wxs
  Loaders/OSX-IMK/English.lproj/InfoPlist.strings
  Loaders/OSX-IMK/zh_TW.lproj/InfoPlist.strings
  Loaders/OSX-IMK/zh_CN.lproj/InfoPlist.strings
  Distributions/Takao/DatabaseCooker/Makefile.SmartMandarin
  Distributions/Takao/TrackerMaker/TrackerMaker.h
  
  ModulePackages/YKAFWordCount/YKAFWordCount.vcproj
  ModulePackages/YKAFWordCount/YKAFWordCountPackage-Info.plist
  ModulePackages/YKAFWordCount/YKAFWordCount-Windows.plist
  ModulePackages/OVAFPhraseConverter/YKPhraseConverter.vcproj
  ModulePackages/OVAFPhraseConverter/YKAFPhraseConverter-Info.plist
  ModulePackages/OVAFPhraseConverter/YKPhraseConverter-Windows.plist
  ModulePackages/OVAFReverseLookup/YKReverseLookup.vcproj
  ModulePackages/OVAFReverseLookup/YKReverseLookup-Info.plist
  ModulePackages/OVAFReverseLookup/YKReverseLookup-Windows.plist
  
  # Windows beacon
  Distributions/Takao/WinBeacon/Program.cs
  Loaders/Windows-IMM/BaseIMEUI/Config.cs
  ModulePackages/OVAFSearch/OVAFSearch.cpp
  Distributions/Takao/Installer-OSX-IMK/Resources/postflight
  Distributions/Takao/Installer-OSX-TSM/Resources/postflight
  Distributions/Takao/Installer-OSX-IMK/Resources/preflight
  Distributions/Takao/Installer-OSX-TSM/Resources/preflight
  
  Distributions/Takao/Installer-Windows/Installer.sed
  Distributions/Takao/Installer-Windows/Installer64.sed
  Distributions/Takao/Installer-Windows/SupplementInstaller.sed
  Distributions/Takao/Installer-Windows/ExtraModules.sed
  Distributions/Takao/Installer-Windows/makedist.bat
  
  Utilities/PhraseEditor/OSX/Info.plist 
  Utilities/PhraseEditor/Windows/AssemblyInfo.cpp
  Utilities/CinInstaller/Windows/AssemblyInfo.cpp
  
  Distributions/Takao/Installer-OSX-ExtraModules/makedmg.py
  Distributions/Takao/Installer-OSX-DB/makedmg.py  
}

if ARGV.size < 1
  STDERR.puts "usage: verison-upper version"
  exit 1
end

STDERR.puts "WARNING: REMOVE 'BETA' STRING IN THE FORMAL RELEASE."

files.each do |file|
  # system "ls -l #{file}"
  set_version(file, ARGV[0])
end

STDERR.puts "Changes OS X dmg backgrounds"

DMG_BACKGROUND_ORIGINAL = "Distributions/Takao/Installer-OSX-IMK/Artwork/DmgBackground-org.jpg"
DMG_BACKGROUND_IMK = "Distributions/Takao/Installer-OSX-IMK/Artwork/DmgBackground.jpg"
DMG_BACKGROUND_TSM = "Distributions/Takao/Installer-OSX-TSM/Artwork/DmgBackground.jpg"

version_parts = ARGV[0].split(/\./)    
maj_min_ver = "#{version_parts[0]}.#{version_parts[1]}"


system "./Distributions/Takao/PrecompiledTools/TextOverlay #{DMG_BACKGROUND_ORIGINAL} #{DMG_BACKGROUND_IMK} \"正式版 #{ARGV[0]}\nFor Mac OS X Leopard\nand Snow Leopard\" 168 50 10.0 Helvetica"
system "./Distributions/Takao/PrecompiledTools/TextOverlay #{DMG_BACKGROUND_ORIGINAL} #{DMG_BACKGROUND_TSM} '正式版 #{ARGV[0]} for Mac OS X Tiger' 175 77 10.0 Helvetica"

