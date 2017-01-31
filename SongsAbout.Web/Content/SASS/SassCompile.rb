# require "sass"
# options = {
#   cache: true,
#   syntax: :sass,
#   style: :compressed,
#   filename: "site.scss"
# }

# render = Sass::Engine.new(File.read("site.scss"), options).render
# File.write("../site2.css", render)
opts = Sass::Exec::SassScss.new(ARGV, :sass)
opts.parse!
