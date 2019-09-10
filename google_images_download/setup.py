from setuptools import find_packages, setup
from package import Package

setup(
    author="Ami Mahloof",
    author_email="author@email.com",
    packages=find_packages(),
    include_package_data=True,
    cmdclass={
        "package": Package
    }
)
